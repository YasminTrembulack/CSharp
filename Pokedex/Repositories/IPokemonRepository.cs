namespace PokeAPI.Repositories;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PokeAPI.Models;

public interface IPokemonRepository
{
<<<<<<< HEAD
    Task<IEnumerable<Pokemon>> GetPokemon(int pageIndex, int pageSize);
    void SavePokemonAsync(String name);
=======
    Task<IEnumerable<Pokemon>> GetPokemons(int pageIndex, int pageSize);
>>>>>>> 85cdeb49e5a271dea2ed2f864d89ca0e82d846dd
    Task<Pokemon?> GetById(Guid guid);
    Task<Pokemon?> GetByName(string name);
    Task<Pokemon> Create(Pokemon pokemon);
}