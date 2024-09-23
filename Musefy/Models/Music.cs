namespace Musify.Models;

public class Music : BaseModel
{
    public required string Title { get; set; }
    public required string Artist { get; set; }
    public required string Duration { get; set; }
    public required int Year { get; set; }
    public required string Lyrics { get; set; }
    public required string Album { get; set; }
    public User? User { get; set; } = null;
}
