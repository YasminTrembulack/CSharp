using Microsoft.EntityFrameworkCore;

namespace  Musify.Services;

using Models;
using Repositories;

public class MusicInfoRepositoryService(MusifyContext ctx) : IMusicRepository
{
    public async Task<Music> Add(Music music)
    {
        await ctx.AddAsync(music);
        await ctx.SaveChangesAsync();
        return music;
    }

    public async Task<Music?> GetById(Guid id)
        => await ctx.Musics.FindAsync(id);

    public async Task<IEnumerable<Music>> GetMusics(int pageIndex, int pageSize)
    => await ctx.Musics
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    public async Task Update(Music music)
    {
        ctx.Musics.Update(music);
        await ctx.SaveChangesAsync();
    }
}