using Microsoft.AspNetCore.Mvc;

namespace Musify.Controllers;

using System.Diagnostics;
using Models;
using Repositories;

[ApiController]
[Route("auth")]
public class AuthController() : ControllerBase
{
    [HttpPost("/login")]
    public async Task<ActionResult> Login(User id)
    {
        // var musicInfo = await repo.GetById(id);

        // if (musicInfo is null)
        //     return NotFound();

        return Ok(null);
    }

    [HttpPost("/register")]
    public async Task<ActionResult> Register(User payload)
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
}