
using PokeAPI.Models;
using PokeAPI.Repositories;

public class PokemonRepository : IPokemonRepository
{

    public Task<Pokemon> Create(Pokemon pokemon)
    {
        throw new NotImplementedException();
    }

    public Task<Pokemon?> GetById(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<Pokemon?> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Pokemon>> GetPokemons(int pageIndex, int pageSize)
    {
        throw new NotImplementedException();
    }
}