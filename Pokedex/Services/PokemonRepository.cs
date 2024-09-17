<<<<<<< HEAD
using System.Net;
=======

>>>>>>> 85cdeb49e5a271dea2ed2f864d89ca0e82d846dd
using PokeAPI.Models;
using PokeAPI.Repositories;

public class PokemonRepository : IPokemonRepository
{

<<<<<<< HEAD
    readonly PokedexContext ctx;
    public PokemonRepository(PokedexContext context)
        => ctx = context;
    public Task<IEnumerable<Pokemon>> GetPokemon(int pageIndex, int pageSize)
    {
        throw new NotImplementedException();
    }
    
    public Task<Pokemon> Add(Pokemon team)
=======
    public Task<Pokemon> Create(Pokemon pokemon)
>>>>>>> 85cdeb49e5a271dea2ed2f864d89ca0e82d846dd
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

<<<<<<< HEAD
    public async Task SavePokemonAsync(string name)
    {
        var html = GetPage($"https://pokemon.fandom.com/wiki/{name}");
        
    }


    static async Task<string> GetPage(string url){
        using var client = new HttpClient(
            new HttpClientHandler {
                Proxy = new WebProxy{
                    Address = new Uri("http://disrct:etsps2024401@rb-proxy-ca2.bosch.com:8080"),
                    Credentials = new NetworkCredential("disrct", "etsps2024401")
                }
            }
        );
        var response = await client.GetAsync(url);
        var html = await response.Content.ReadAsStringAsync();
        return html;
=======
    public Task<IEnumerable<Pokemon>> GetPokemons(int pageIndex, int pageSize)
    {
        throw new NotImplementedException();
>>>>>>> 85cdeb49e5a271dea2ed2f864d89ca0e82d846dd
    }
}