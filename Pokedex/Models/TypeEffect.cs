namespace PokeAPI.Models;

public class TypeEffect : BaseModel
{
    public required Type Attacker { get; set; }
    public required Type Receiver { get; set; }
    public float Multiplier { get; set; }
}