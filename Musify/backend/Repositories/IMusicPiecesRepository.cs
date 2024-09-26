namespace Musify.Repositories;

using System;
using System.Threading.Tasks;
using Musify.Models;

public interface IMusicPiecesRepository
{
    Task<MusicPieces?> GetById(Guid id);
    Task<MusicPieces?> Add(MusicPieces music_pieces);
}