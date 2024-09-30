namespace Musify.Models;

public class User : BaseModel
{
    public required string Username { get; set; }
    public required string FullName { get; set; }
    public required string Password { get; set; }
    public required DateTime BirthDate { get; set; }
    public required string Role { get; set; }
    public ICollection<Music> Musics { get; set;} = [];
}

