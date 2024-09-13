namespace PokeAPI.Models;

public class Pokemon : BaseModel
{
    public required int Index { get; set; }
    public required string Name { get; set; }
    public required Type MainType { get; set;}
    public Type? SecondType { get; set;}
    public required Guid BaseStatsId { get; set;}
    public required Guid MinStatsId { get; set;}
    public required Guid MaxStatsId { get; set;}
    public required Generation IntroducedIn { get; set; }
    public Guid? EvolvesFrom { get; set; } = null!;
}