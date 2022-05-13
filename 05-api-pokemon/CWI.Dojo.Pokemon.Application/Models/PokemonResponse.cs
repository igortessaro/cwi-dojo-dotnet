using Newtonsoft.Json;

namespace CWI.Dojo.Pokemon.Application.Models
{
    public sealed class PokemonResponse
    {
        [JsonProperty(PropertyName = "pokemon_entries")]
        public IList<Pokemon> Pokemons { get; set; }
    }
}
