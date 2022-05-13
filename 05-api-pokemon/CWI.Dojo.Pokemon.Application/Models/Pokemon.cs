using Newtonsoft.Json;

namespace CWI.Dojo.Pokemon.Application.Models
{
    public sealed class Pokemon
    {
        [JsonProperty(PropertyName = "pokemon_species")]
        public Specie Specie { get; set; }

        [JsonProperty(PropertyName = "entry_number")]
        public int Id { get; set; }
    }
}
