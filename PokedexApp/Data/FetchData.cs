using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PokedexApp.Models;

namespace PokedexApp.Data
{
    public class FetchData
    {
        public static async Task<List<Pokemon>> GetPokemon()
        {
            HttpClient request = new HttpClient();
            var response = await request.GetStringAsync("https://pokeapi.co/api/v2/pokemon?limit=151");
            PokemonParser poke = JsonConvert.DeserializeObject<PokemonParser>(response);
            return poke.results;
        }

        public static async Task<PokemonInfo> GetPokemonInfo(int id)
        {
            HttpClient request = new HttpClient();
            var response = await request.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{id}/");
            PokemonInfo pokeInfo = JsonConvert.DeserializeObject<PokemonInfo>(response);
            return pokeInfo;
        }
    }
}