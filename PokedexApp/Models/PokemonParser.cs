using System.Collections.Generic;

namespace PokedexApp.Models
{
    public class PokemonParser
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Pokemon> results { get; set; }
    }
}