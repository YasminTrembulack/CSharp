using Microsoft.AspNetCore.Mvc;

namespace Musify.Controllers;

using System.Diagnostics;
using Models;
using Repositories;

[ApiController]
[Route("music")]
public class MusicInfoController(IMusicRepository repo) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult> GetMusics(int pageIndex = 1, int pageSize = 4)
    {
        // var musicInfos = await repo.GetMusicInfos(pageIndex, pageSize);
        return Ok(null);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetMusicById(Guid id)
    {
        // var musicInfo = await repo.GetById(id);

        // if (musicInfo is null)
        //     return NotFound();

        return Ok(null);
    }

    [HttpPost]
    public async Task<ActionResult> CreateMusic(MusicDTO payload)
    {

        // var music = new Music
        // {
        //     Title = payload.Title,
        //     Artist = payload.Artist,
        //     Duration = payload.Duration,
        //     Year = payload.Year,
        //     Lyrics = payload.Lyrics,
        //     Album = payload.Album,
        //     // Genres = genres
        // };
        // await repo.Add(music);

        return Ok(null);
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