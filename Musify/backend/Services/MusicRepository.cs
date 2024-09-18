using Microsoft.EntityFrameworkCore;

namespace  Musify.Services;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Repositories;

public class MusicRepository(MusicContext ctx) : IMusicRepository
{
    public async Task<Music> Add(Music music)
    {
        await ctx.AddAsync(music);
        await ctx.SaveChangesAsync();
        return music;
    }

    public async Task<Music?> GetById(Guid guid)
        => await ctx.Musics.FindAsync(guid);

}