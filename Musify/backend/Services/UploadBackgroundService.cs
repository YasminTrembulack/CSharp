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
        var musicService = scope.ServiceProvider.GetRequiredService<IMusicRepository>();
        var musicPieceService = scope.ServiceProvider.GetRequiredService<IMusicPiecesRepository>();

        var folder = request.TempFolder;
        var processUp = request.Process;
        var MusicId = request.MusicInfoId;
        var music = await musicService.GetById(MusicId);

        if (music == null)
        {
            processUp.LoadingBar = 100;
            processUp.Finished = true;
            processUp.Status = "Error: Music not found.";
            await musicUploadService.UpdateProcess(processUp);
            return;
        }
        System.Console.WriteLine("Folder: "+ folder);
        var filesPath = Path.Combine(folder, "music.mp3");
        var uploadPath = Path.Combine(folder, "music.m3u8");

        System.Console.WriteLine("filesPath: "+ filesPath);
        System.Console.WriteLine("uploadPath: "+ uploadPath);


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

        var files = Directory.GetFiles(folder);

        var header = files
            .FirstOrDefault(f => f.EndsWith(".m3u8"))!;
        var parts = files
            .Where(f => f != header);

        var dict = new Dictionary<string, Guid>();

        foreach (var part in parts)
        {
            var music_pieces = new MusicPieces
            {
                Bytes = await File.ReadAllBytesAsync(part),
                Music = music
            };
            await musicPieceService.Add(music_pieces);

            var fileName = Path.GetFileName(part);
            dict.Add(fileName, music_pieces.Id);
        }

        processUp.LoadingBar = 80;
        await musicUploadService.UpdateProcess(processUp);

        var lines = await File.ReadAllLinesAsync(header);

        var sb = new StringBuilder();
        Console.WriteLine("SB");
        foreach (var line in lines)
        {
            if (!dict.TryGetValue(line, out var id))
            {
                sb.AppendLine(line);
                Console.WriteLine($"APPEND  {line}");

                continue;
            }

            sb.AppendLine(id.ToString());
            Console.WriteLine($"APPEND  {id}");

        }
        var processedHeader = sb.ToString();

        processUp.LoadingBar = 95;
        await musicUploadService.UpdateProcess(processUp);

        var contentHeader = new MusicPieces
        {
            Bytes = Encoding.UTF8.GetBytes(processedHeader),
            Music = music
        };
        
        // Directory.Delete(folder, true);

        processUp.LoadingBar = 100;
        processUp.Finished = true;
        processUp.Status = "Finished";
        var newHeader = await musicPieceService.Add(contentHeader);
        Console.WriteLine("headerId: " + header.ToString());

        var tfile = TagLib.File.Create(filesPath);
        TimeSpan duration = tfile.Properties.Duration;
        System.Console.WriteLine(duration);

        music.MusicHeaderId = newHeader?.Id;
        await musicService.Update(music);
        await musicUploadService.UpdateProcess(processUp);
        return;
    }
}