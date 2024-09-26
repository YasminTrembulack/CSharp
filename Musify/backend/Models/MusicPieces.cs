namespace Musify.Models;

public class MusicPieces : BaseModel
{
    public required byte[] Bytes { get; set; }
    public required Music Music { get; set; }
}
