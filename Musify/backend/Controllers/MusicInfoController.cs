using Microsoft.AspNetCore.Mvc;

namespace Musify.Controllers;

using System.Diagnostics;
using Models;
using Repositories;

[ApiController]
[Route("music-info")]
public class MusicInfoController(IMusicInfoRepository repo) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult> GetMusics(
        int pageIndex = 1, int pageSize = 4)
    {
        var musicInfos = await repo.GetMusicInfos(pageIndex, pageSize);
        return Ok(musicInfos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetMusicInfoById(Guid id)
    {
        var musicInfo = await repo.GetById(id);

        if (musicInfo is null)
            return NotFound();

        return Ok(musicInfo);
    }

    [HttpPost("{musicId}")]
    public async Task<ActionResult> CreateMusicInfo(Guid musicId, MusicInfoDTO payload)
    {

        // ARRUMAR O GENTE POIS ELE É MUITOS PARA MUITOS ENT TEM A TABELA RELACIONAL
        ICollection<Genre> genres = [];
        foreach (var item in payload.Genres)
        {
            var genre = new Genre
            {
                Name = item,
            };
            genres.Add(genre);
        }

        var musicInfo = new MusicInfo
        {
            Title = payload.Title,
            Artist = payload.Artist,
            Duration = payload.Duration,
            Year = payload.Year,
            Lyrics = payload.Lyrics,
            Album = payload.Album,
            Genres = genres,
            Music = musicId,
            VideoClip = null
        };
        await repo.Add(musicInfo);

        return Created("/music-info", musicInfo);
    }

    public record MusicInfoDTO(
        string Title,
        string Artist,
        string Duration,
        int Year,
        string Lyrics,
        string Album,
        List<string> Genres
    );

}