using static System.IO.File;
using Microsoft.AspNetCore.Mvc;

namespace Musify.Controllers;

using System.Diagnostics;
using System.Text;
using Models;
using Services;
using Repositories;

[ApiController]
[Route("music")]
public class MusicController(IMusicRepository repo) : ControllerBase
{

    [HttpGet("{id}")]
    public async Task<ActionResult> GetMusicById(Guid id)
    {
        var music = await repo.GetById(id);

        if (music is null)
            return NotFound();

        return Ok(music);
    }
}