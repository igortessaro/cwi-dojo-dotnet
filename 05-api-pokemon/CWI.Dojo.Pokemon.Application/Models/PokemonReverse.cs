using Newtonsoft.Json;

namespace CWI.Dojo.Pokemon.Application.Models
{
    public class PokemonReverse
    {
        [JsonProperty(PropertyName = "other-name")]
        public string OtherName { get; set; }

        [JsonProperty(PropertyName = "identifier")]
        public int Identifier { get; set; }
    }
}
