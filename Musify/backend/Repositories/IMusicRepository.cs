namespace Musify.Repositories;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Musify.Models;

public interface IMusicRepository
{
    Task<Music?> GetById(Guid guid);
    Task<Music> Add(Music music);
}