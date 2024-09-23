using System.Diagnostics;
using System.Text;
using Musify.Models;
using Musify.Repositories;

namespace Musify.Services;

public class UploadBackgroundService(FileUploadRequestQueueService service, IServiceProvider serviceProvider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var uploadRequest = await service.Queue.Reader.ReadAsync(stoppingToken);

            await ProcessUpload(uploadRequest);
        }
    }

    private async Task ProcessUpload(FileUploadRequest request)
    {
        using var scope = serviceProvider.CreateScope();
        
        var musicUploadService = scope.ServiceProvider.GetRequiredService<IMusicUploadService>();

        var file = request.File;
        var processUp = request.Process;
        var MusicInfoId = request.MusicInfoId;

        using var stream = file.OpenReadStream();
        var ms = new MemoryStream();
        await stream.CopyToAsync(ms);
        var bytes = ms.ToArray();

        var dir = Directory.CreateTempSubdirectory("music");
        var filesPath = Path.Combine(dir.FullName, "music.mp3");
        var uploadPath = Path.Combine(dir.FullName, "music.m3u8");
        await File.WriteAllBytesAsync(filesPath, bytes);

        var ffmpegPath = Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg.exe");
        string strCmdText = $"{ffmpegPath} -i {filesPath} -codec copy -start_number 0 -hls_time 10 -hls_list_size 0 -f hls {uploadPath}";

        var processInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/C {strCmdText}",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        var process = new Process { StartInfo = processInfo };
        process.Start();

        processUp.LoadingBar = 30;
        await musicUploadService.UpdateProcess(processUp);

        // Ler saída e erro de forma assíncrona
        var outputTask = process.StandardOutput.ReadToEndAsync();
        var errorTask = process.StandardError.ReadToEndAsync();

        await Task.WhenAll(outputTask, errorTask);
        process.WaitForExit();

        processUp.LoadingBar = 70;
        await musicUploadService.UpdateProcess(processUp);

        var files = Directory.GetFiles(dir.FullName);

        var header = files
            .FirstOrDefault(f => f.EndsWith(".m3u8"))!;
        var parts = files
            .Where(f => f != header);

        var dict = new Dictionary<string, Guid>();

        foreach (var part in parts)
        {
            var music = new Music
            {
                Bytes = await File.ReadAllBytesAsync(part)
            };
            await musicUploadService.AddMusic(music);

            var fileName = Path.GetFileName(part);
            dict.Add(fileName, music.Id);
        }

        processUp.LoadingBar = 80;
        await musicUploadService.UpdateProcess(processUp);

        var lines = await File.ReadAllLinesAsync(header);

        var sb = new StringBuilder();
        System.Console.WriteLine("SB");
        foreach (var line in lines)
        {
            if (!dict.TryGetValue(line, out var id))
            {
                sb.AppendLine(line);
                System.Console.WriteLine($"APPEND  {line}");

                continue;
            }

            sb.AppendLine(id.ToString());
            System.Console.WriteLine($"APPEND  {id}");

        }
        var processedHeader = sb.ToString();

        processUp.LoadingBar = 95;
        await musicUploadService.UpdateProcess(processUp);

        var contentHeader = new Music
        {
            Bytes = Encoding.UTF8.GetBytes(processedHeader)
        };
        
        Directory.Delete(dir.FullName, true);

        processUp.LoadingBar = 100;
        processUp.Finished = true;
        processUp.Status = "Finished";
        var headerId = await musicUploadService.AddMusic(contentHeader);
        System.Console.WriteLine("headerId: " + headerId.ToString());

        var musicInfoUploadService = scope.ServiceProvider.GetRequiredService<IMusicInfoRepository>();

        await musicInfoUploadService.UpdateMusicHeader(MusicInfoId, headerId);
        await musicUploadService.UpdateProcess(processUp);
        return;
    }
}