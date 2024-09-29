using Microsoft.AspNetCore.Mvc;

namespace Musify.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Musify.DTO;
using Musify.Models;
using Repositories;

[ApiController]
[Route("music")]
public class MusicInfoController(IMusicRepository repo, IUserRepository repoUser) : ControllerBase
{

    [HttpGet]
    [Authorize]
    public async Task<ActionResult> GetMusics(int pageIndex = 1, int pageSize = 4)
    {
        var music = await repo.GetMusics(pageIndex, pageSize);
        return Ok(music);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetMusicById(Guid id)
    {
        var music = await repo.GetById(id);

        if (music is null)
            return NotFound();

        return Ok(music);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult> CreateMusic(MusicCreatePayload payload)
    {
        var user_id = User.FindFirst("Id")?.Value;
        
        var user = await repoUser.GetById(Guid.Parse("29c5125f-46e7-4ead-9210-55d1c0c70870"));

        var music = new Music
        {
            Title = payload.Title,
            Artist = payload.Artist,
            Duration = payload.Duration,
            Year = payload.Year,
            Lyrics = payload.Lyrics,
            Album = payload.Album,
            User = user!,
            Pieces = [],
        };
        var new_music = await repo.Add(music);

        return Ok(new MusicCreateResponse("Music created with success", new_music.Id));
    }

    

}