namespace PokeAPI.Models;

public class Type : BaseModel
{
    public required string Name { get; set; }
    public required string Color { get; set; }
}