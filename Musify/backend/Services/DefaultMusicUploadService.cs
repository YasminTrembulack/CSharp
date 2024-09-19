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
        var existingUpload = await ctx.Uploads.FindAsync(update.Id);

        existingUpload.LoadingBar = update.LoadingBar;
        existingUpload.Status = update.Status;
        existingUpload.Finished = update.Finished;

        await ctx.SaveChangesAsync();

    }

    public async Task AddMusic(Music music)
    {
        await ctx.Musics.AddAsync(music);
        await ctx.SaveChangesAsync();
    }

    public async Task<Guid> Upload(IFormFile file)
    {
        UploadProcess process = new UploadProcess();
        ctx.AddAsync(process);
        await ctx.SaveChangesAsync();

        await queueService.Queue.Writer.WriteAsync(new(file, process));

        return process.Id;
    }

}