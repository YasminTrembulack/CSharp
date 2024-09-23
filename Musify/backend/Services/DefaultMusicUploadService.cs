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

        await queueService.Queue.Writer.WriteAsync(new(file, process, musicInfoId));

        return process.Id;
    }

}