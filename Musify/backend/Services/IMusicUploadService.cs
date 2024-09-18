using Microsoft.AspNetCore.Mvc;

namespace Musify.Services;

using Models;

public interface IMusicUploadService
{
    Task<Guid> Upload(IFormFile file);
    Task<UploadProcess> Verify(Guid id);
    Task<bool> UpdateProcess(UploadProcess update);
}