namespace Musify.Models;

public class MusicGenre : BaseModel
{
    public required Music Music { get; set; }
    public required Genre Genre { get; set; }
}
