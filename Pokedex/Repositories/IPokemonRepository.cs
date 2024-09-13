namespace PokeAPI.Repositories;

using PokeAPI.Models;

public interface IPokemonRepository
{
    Task<IEnumerable<Pokemon>> GetTeams(int pageIndex, int pageSize);
    Task<Pokemon?> GetById(Guid guid);
    Task<Pokemon?> GetByName(String name);
    Task<Pokemon> Add(Pokemon team);
}