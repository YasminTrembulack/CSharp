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
        var numberMusics = repo.GetNumberMusics();
        var music = await repo.GetMusics(pageIndex, pageSize);
        return Ok(new MusicGetResponse(music, numberMusics));
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
    public async Task<ActionResult> CreateMusic(MusicCreatePayload payload, IFormFile Image)
    {
        var user_id = User.FindFirst("Id")?.Value;
        // Console.WriteLine("USER ID ------> "+user_id);
        
        var user = await repoUser.GetById(Guid.Parse(user_id!));
        if (user == null)
            return BadRequest("User not found");

        byte[]? disc = null;
        using (var fs1 = Image.OpenReadStream())
        using (var ms1 = new MemoryStream())
        {
            fs1.CopyTo(ms1);
            disc = ms1.ToArray();
        }

        var music = new Music
        {
            Title = payload.Title,
            Artist = payload.Artist,
            Duration = "",
            Year = payload.Year,
            Lyrics = payload.Lyrics,
            Album = payload.Album,
            User = user,
            Pieces = [],
            Discography = disc
        };
        var new_music = await repo.Add(music);

        return Ok(new MusicCreateResponse("Music created with success", MusicResponse.Build(new_music)));
    }

    

}