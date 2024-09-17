namespace PokeAPI.Repositories;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PokeAPI.Models;

public interface IPokemonRepository
{
    Task<IEnumerable<Pokemon>> GetPokemons(int pageIndex, int pageSize);
    Task<Pokemon?> GetById(Guid guid);
    Task<Pokemon?> GetByName(string name);
    Task<Pokemon> Create(Pokemon pokemon);
}