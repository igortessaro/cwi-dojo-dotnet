using CWI.Dojo.Pokemon.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CWI.Dojo.Pokemon.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IPokemonService _pokemonService;

        public PokemonController(IHttpClientFactory httpClientFactory, IPokemonService pokemonService)
        {
            this._httpClientFactory = httpClientFactory;
            this._pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this._pokemonService.GetAll();

            return Ok(result);
        }
    }
}
