namespace PokeAPI.Models;

public class Pokemon 
{
    public required string Name { get; set; }
    public required Type MainType { get; set;}
    public Type? SecondType { get; set;}
    public required Stats BaseStats { get; set;}
    public required Stats MinStats { get; set;}
    public required Stats MaxStats { get; set;}
    public Pokemon? Evolution { get; set; }
    public required Generation IntroducedIn { get; set; }

}