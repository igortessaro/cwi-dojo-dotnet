using CWI.Dojo.Pokemon.Application.Models;
using Newtonsoft.Json;

namespace CWI.Dojo.Pokemon.Application.Services
{
    public sealed class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IList<Models.Pokemon>> GetAll()
        {
            int pokedexId = 2;

            var message = await this._httpClient.GetAsync($"pokedex/{pokedexId}");

            if (!message.IsSuccessStatusCode)
            {
                return new List<Models.Pokemon>();
            }

            var content = await message.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<PokemonResponse>(content);

            return result.Pokemons;
        }
    }
}
