    
using Microsoft.EntityFrameworkCore;

namespace  Musify.Services;

using Models;
using Repositories;

public class MusicPiecesRepositoryService(MusifyContext ctx) : IMusicPiecesRepository
{
    public async Task<MusicPieces?> Add(MusicPieces music_pieces)
    {
        await ctx.MusicPieces.AddAsync(music_pieces);
        await ctx.SaveChangesAsync();
        return music_pieces;
    }

    public async Task<MusicPieces?> GetById(Guid id)
     => await ctx.MusicPieces.FindAsync(id);
}
    
    