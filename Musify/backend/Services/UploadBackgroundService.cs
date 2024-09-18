namespace Musify.Services;

public class UploadBackgroundService(FileUploadRequestQueueService service, IMusicUploadService uploadService) : BackgroundService
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

        var file = request.File;
        var process = request.Process;

        process.Status = "Teste...";
        bool result = await uploadService.UpdateProcess(process);
        System.Console.WriteLine(result);


        // var stream = file.OpenReadStream();
        // var ms = new MemoryStream();
        // await stream.CopyToAsync(ms);
        // var bytes = ms.GetBuffer();

        // var dir = Directory.CreateTempSubdirectory("music");
        // var filesPath = Path.Combine(dir.FullName, "music.mp3");
        // var uploadPath = Path.Combine(dir.FullName, "music.m3u8");
        // await File.WriteAllBytesAsync(filesPath, bytes);

        // var ffmpegPath = Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg.exe");
        // string strCmdText = $"{ffmpegPath} -i {filesPath} -codec copy -start_number 0 -hls_time 10 -hls_list_size 0 -f hls {UploadPath}";

        // var processInfo = new ProcessStartInfo
        // {
        //     FileName = "cmd.exe",
        //     Arguments = $"/C {strCmdText}",
        //     RedirectStandardOutput = true,
        //     RedirectStandardError = true,
        //     UseShellExecute = false,
        //     CreateNoWindow = true
        // };

        // await Task.Factory.StartNew(() =>
        // {
        //     var process = new Process { StartInfo = processInfo };
        //     process.Start();
        //     var output = process.StandardOutput.ReadToEnd();
        //     var error = process.StandardError.ReadToEnd();
        //     process.WaitForExit();
        // });

        // var files = Directory.GetFiles(dir.FullName);
        // System.Console.WriteLine(dir.FullName);

        // foreach (var item in files)
        // {
        //     System.Console.WriteLine(item);
        // }

        // var header = files
        //     .FirstOrDefault(f => f.EndsWith(".m3u8"))!;
        // var parts = files
        //     .Where(f => f != header);

        // var dict = new Dictionary<string, Guid>();

        // foreach (var part in parts)
        // {
        //     System.Console.WriteLine(part);
        //     var music = new Music
        //     {
        //         Bytes = ReadAllBytes(part)
        //     };
        //     // await repo.Add(music);

        //     var fileName = Path.GetFileName(part);
        //     dict.Add(fileName, music.Id);
        // }

        // var lines = ReadAllLines(header);
        // var sb = new StringBuilder();
        // foreach (var line in lines)
        // {
        //     if (!dict.TryGetValue(line, out var id))
        //     {
        //         sb.AppendLine(line);
        //         continue;
        //     }

        //     sb.AppendLine(id.ToString());
        // }
        // var processedHeader = sb.ToString();

        // var contentHeader = new Music
        // {
        //     Bytes = Encoding.UTF8.GetBytes(processedHeader)
        // };
        // // await repo.Add(contentHeader);
    }
}