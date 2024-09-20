using Microsoft.AspNetCore.Mvc;

namespace Musify.Services;

using Models;

public interface IMusicUploadService
{
    Task<Guid> Upload(IFormFile file);
    Task<UploadProcess?> Verify(Guid id);
    Task UpdateProcess(UploadProcess update);
    Task<Guid> AddMusic(Music music);
}