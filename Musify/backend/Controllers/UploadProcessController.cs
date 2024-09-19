using System.Text;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

namespace Musify.Controllers;

using Models;
using Services;
using Repositories;

[ApiController]
[Route("upload-music")]
public class UploadProcessController(IMusicUploadService uploader) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateMusic(List<IFormFile> payloadFiles)
    {
        var file = payloadFiles.FirstOrDefault();
        if (file is null)
            return BadRequest();
        
        var processId = await uploader.Upload(file);
        return Ok(processId);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetUploadProcess(Guid id)
    {
        var process = await uploader.Verify(id);

        if (process == null)
            return NotFound();
        return Ok(process);
    }
}