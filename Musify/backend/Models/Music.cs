namespace Musify.Models;

public class Music : BaseModel
{
    public required string Title { get; set; }
    public required string Artist { get; set; }
    public required string Duration { get; set; }
    public required int Year { get; set; }
    public string? Lyrics { get; set; }
    public required string Album { get; set; }
    public required User User { get; set; }
    public required ICollection<MusicPieces> Pieces { get; set; }
    public Guid? MusicHeaderId { get; set; }
    public MusicPieces? MusicHeader { get; set; } = null;
    public byte[]? Discography{ get; set; } = null;
}
