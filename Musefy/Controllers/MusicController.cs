using Microsoft.AspNetCore.Mvc;

namespace Musify.Controllers;

using Musify.Models;
using Repositories;

[ApiController]
[Route("music")]
public class MusicInfoController(IMusicRepository repo) : ControllerBase
{

    [HttpGet]
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
    public async Task<ActionResult> CreateMusic(MusicDTO payload)
    {
        var music = new Music
        {
            Title = payload.Title,
            Artist = payload.Artist,
            Duration = payload.Duration,
            Year = payload.Year,
            Lyrics = payload.Lyrics,
            Album = payload.Album,
            User = null!,
            Pieces = []
        };
        await repo.Add(music);

        return Ok(music.Id);
    }

    public record MusicDTO(
        string Title,
        string Artist,
        string Duration,
        int Year,
        string Lyrics,
        string Album
    );

}