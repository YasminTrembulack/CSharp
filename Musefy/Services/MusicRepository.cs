namespace  Musify.Services;

using System;
using System.Threading.Tasks;
using Models;
using Repositories;

public class MusicRepository(MusifyContext ctx) : IMusicRepository
{
    public async Task<Music> Add(Music music)
    {
        await ctx.AddAsync(music);
        await ctx.SaveChangesAsync();
        return music;
    }

    public async Task<Music?> GetById(Guid guid)
        => await ctx.Musics.FindAsync(guid);

    public async Task<Music> GetMusics()
        => await ctx.Musics.FindAsync();
}