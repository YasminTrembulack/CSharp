using Microsoft.EntityFrameworkCore;

namespace  Musify.Services;

using Models;
using Repositories;

public class MusicInfoRepository(MusifyContext ctx) : IMusicRepository
{
    public async Task<Music> Add(Music music)
    {
        await ctx.AddAsync(music);
        await ctx.SaveChangesAsync();
        return music;
    }

    public async Task<Music?> GetById(Guid guid)
        => await ctx.Musics.FindAsync(guid);

    public async Task<IEnumerable<Music>> GetMusics(int pageIndex, int pageSize)
    => await ctx.Musics
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

}