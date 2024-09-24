namespace Musify.Repositories;

using System;
using System.Threading.Tasks;
using Musify.Models;

public interface IMusicRepository
{
    Task<Music?> GetById(Guid guid);
    Task<Music> Add(Music music);
    Task<IEnumerable<Music>> GetMusics(int pageIndex, int pageSize);
}