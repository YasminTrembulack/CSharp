using Microsoft.AspNetCore.Mvc;
namespace Musify.Services;

using System.Runtime.CompilerServices;
using Models;
using Repositories;

public class DefaultMusicUploadService(FileUploadRequestQueueService queueService, MusicContext ctx) : IMusicUploadService
{

    public async Task<UploadProcess?> Verify(Guid id)
    {
        var result = await ctx.Uploads.FindAsync(id);

        return result;
    }


    public async Task UpdateProcess(UploadProcess update)
    {
        // var existingUpload = await ctx.Uploads.FindAsync(update.Id);
        ctx.Uploads.Update(update);
        await ctx.SaveChangesAsync();
    }

    public async Task<Guid> AddMusic(Music music)
    {
        await ctx.Musics.AddAsync(music);
        await ctx.SaveChangesAsync();
        return music.Id;
    }

    public async Task<Guid> Upload(IFormFile file, Guid musicInfoId)
    {
        UploadProcess process = new UploadProcess();
        await ctx.AddAsync(process);
        await ctx.SaveChangesAsync();

        using var stream = file.OpenReadStream();
        using var ms = new MemoryStream();
        await stream.CopyToAsync(ms);
        var buffer = ms.GetBuffer();

        var dir = Directory.CreateTempSubdirectory("music");
        var filesPath = Path.Combine(dir.FullName, "music.mp3");
        await File.WriteAllBytesAsync(filesPath, buffer);

        await queueService.Queue.Writer.WriteAsync(new(dir.FullName, process, musicInfoId));

        return process.Id;
    }

}