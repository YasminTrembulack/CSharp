namespace PokeAPI.Repositories;

using PokeAPI.Models;

public interface IPokemonRepository
{
    Task<IEnumerable<Pokemon>> GetPokemon(int pageIndex, int pageSize);
    void SavePokemonAsync(String name);
    Task<Pokemon?> GetById(Guid guid);
    Task<Pokemon?> GetByName(String name);
    Task<Pokemon> Add(Pokemon team);
}