using Microsoft.EntityFrameworkCore;

namespace  Musify.Services;

using Models;
using Repositories;

public class MusicInfoRepository(MusicContext ctx) : IMusicInfoRepository
{
    public async Task<MusicInfo> Add(MusicInfo musicInfo)
    {
        await ctx.AddAsync(musicInfo);
        await ctx.SaveChangesAsync();
        return musicInfo;
    }

    public async Task<MusicInfo?> GetById(Guid guid)
        => await ctx.MusicInfos.FindAsync(guid);

    public async Task<IEnumerable<MusicInfo>> GetMusicInfos(int pageIndex, int pageSize)
    => await ctx.MusicInfos
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

    public async Task UpdateMusicHeader(Guid id, Guid header)
    {
        var musicInfo = await ctx.MusicInfos.FindAsync(id);

        if (musicInfo == null) 
            return;

        musicInfo.Music = header;
        ctx.MusicInfos.Update(musicInfo);
        await ctx.SaveChangesAsync();
    }
}