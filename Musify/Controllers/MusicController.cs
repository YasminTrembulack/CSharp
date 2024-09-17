using static System.IO.File;
using Microsoft.AspNetCore.Mvc;

namespace Musify.Controllers;

using System.Diagnostics;
using System.Text;
using Models;
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

    [HttpPost("{id}")]
    public async Task<ActionResult> CreateMusic(List<IFormFile> payloadFiles)
    {

        var ms = payloadFiles.First().OpenReadStream();
        var x = new MemoryStream();
        ms.CopyTo(x);
        var bytes = x.GetBuffer();
        var dir = Directory.CreateTempSubdirectory("../uploads");
        var filesPath = Path.Combine(dir.FullName, "music.mp3");

        // ISSO FUNCIONA???
        const string strCmdText = "..\\ffmpeg.exe -i ..\\upload\\music.mp3 -codec: copy -start_number 0 -hls_time 10 -hls_list_size 0 -f hls ..\\upload\\music.m3u8";
        Process.Start("CMD.exe", strCmdText);

        var files = Directory.GetFiles(dir.Name);

        var header = files
            .FirstOrDefault(f => f.EndsWith(".m3u8"))!;
        var parts = files
            .Where(f => f != header);

        var dict = new Dictionary<string, Guid>();

        foreach (var part in parts)
        {
            var music = new Music
            {
                Bytes = ReadAllBytes(part)
            };
            await repo.Add(music);

            var fileName = Path.GetFileName(part);
            dict.Add(fileName, music.Id);
        }

        var lines = ReadAllLines(header);
        var sb = new StringBuilder();
        foreach (var line in lines)
        {
            if (!dict.TryGetValue(line, out var id))
            {
                sb.AppendLine(line);
                continue;
            }

            sb.AppendLine(id.ToString());
        }
        var processedHeader = sb.ToString();

        var contentHeader = new Music
        {
            Bytes = Encoding.UTF8.GetBytes(processedHeader)
        };
        await repo.Add(contentHeader);
        
        return Created("/music", contentHeader.Id);
    }


}