
namespace Musify.Models;

public class MusicInfo : BaseModel
{
    public required string Title { get; set; }

    public required string Artist { get; set; }

    public required string Duration { get; set; }

    public required int Year { get; set; }

    public required string Lyrics { get; set; }

    public required string Album { get; set; }
    
    public required ICollection<Genre> Genres { get; set; }

    public required Guid Music { get; set; }
    public required Guid? VideoClip { get; set; }
}
