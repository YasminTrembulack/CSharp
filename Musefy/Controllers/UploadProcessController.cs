using System.Text;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

namespace Musify.Controllers;

using Models;
using Services;
using Repositories;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("upload")]
public class UploadProcessController(IMusicUploadService uploader) : ControllerBase
{
    [HttpPost("{musicId}")]
    [AllowAnonymous]
    public async Task<ActionResult> UploadMusic(List<IFormFile> payloadFiles, Guid musicId)
    {
        var file = payloadFiles.FirstOrDefault();
        if (file is null)
            return BadRequest("Nenhum arquivo foi enviado.");
        
        if (musicId == Guid.Empty)
            return BadRequest("ID da música inválido.");
        
        var processId = await uploader.Upload(file, musicId);
        return Ok(processId);
    }
    
    [HttpGet("process/{id}")]
    public async Task<ActionResult> GetUploadProcess(Guid id)
    {
        var process = await uploader.Verify(id);

        if (process == null)
            return NotFound();
        return Ok(process);
    }
}