namespace Musify.Repositories;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

public interface IMusicInfoRepository
{
    Task<IEnumerable<MusicInfo>> GetMusicInfos(int pageIndex, int pageSize);
    Task<MusicInfo?> GetById(Guid guid);
    Task<MusicInfo> Add(MusicInfo musicInfo);
    Task UpdateMusicHeader(Guid id, Guid header);
}