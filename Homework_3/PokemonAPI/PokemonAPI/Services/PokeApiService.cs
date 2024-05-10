using Microsoft.Extensions.Caching.Distributed;

namespace PokemonAPI.Services;

public class PokeApiService(IDistributedCache cache)
{
    public async Task<string> GetPokemonList(int offset, int limit)
    {
        string? pokemonResponse = await cache.GetStringAsync($"offset:{offset}limit:{limit}");
        if (String.IsNullOrEmpty(pokemonResponse))
        {
            using HttpClient httpClient = new HttpClient();

            HttpResponseMessage pokemonList =
                await httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon?offset={offset}&limit={limit}");

            if (pokemonList.IsSuccessStatusCode)
            {
                string pokemonContent = await pokemonList.Content.ReadAsStringAsync();
                
                await cache.SetStringAsync(offset.ToString() + limit.ToString(), pokemonContent, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
                
                return pokemonContent;
            }
        }
        else
            return pokemonResponse;

        return String.Empty;
    }

    public async Task<string> GetByNameOrId(string param)
    {
        string? pokemonResponse = await cache.GetStringAsync("pokemon:" + param);
        if (String.IsNullOrEmpty(pokemonResponse))
        {
            using HttpClient httpClient = new HttpClient();

            HttpResponseMessage pokemon = await httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{param}/");

            if (pokemon.IsSuccessStatusCode)
            {
                string pokemonContent = await pokemon.Content.ReadAsStringAsync();
                
                await cache.SetStringAsync(param, pokemonContent, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
                
                return pokemonContent;
            }
        }
        else
            return pokemonResponse;
        
        return String.Empty;
    }

    public async Task<string> GetMove(string param)
    {
        string? moveResponse = await cache.GetStringAsync("move:" + param);
        if (String.IsNullOrEmpty(moveResponse))
        {
            using HttpClient httpClient = new HttpClient();

            HttpResponseMessage move = await httpClient.GetAsync($"https://pokeapi.co/api/v2/move/{param}");

            if (move.IsSuccessStatusCode)
            {
                string moveContent = await move.Content.ReadAsStringAsync();

                await cache.SetStringAsync(param, moveContent, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
                
                return moveContent;
            }
        }
        else
            return moveResponse;
        
        return String.Empty;
    }
}