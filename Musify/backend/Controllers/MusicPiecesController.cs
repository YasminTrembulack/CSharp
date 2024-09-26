using Microsoft.AspNetCore.Mvc;

namespace Musify.Controllers;

using Microsoft.AspNetCore.Authorization;
using Repositories;

[ApiController]
[Route("audio")]
public class MusicPiecesController(IMusicPiecesRepository repo) : ControllerBase
{

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult> GetMusicById(Guid id)
    {
        var audio = await repo.GetById(id);

        if (audio is null)
            return NotFound();
    
        return File(audio.Bytes, "application/octet-stream");
    }


}