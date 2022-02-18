using Microsoft.AspNetCore.Mvc;
using WebApiErrorHandle.Application.Exceptions;

namespace WebApiErrorHandle.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost]
    public IActionResult CreateCustomer([FromBody] Customer customer)
    {
        if (string.IsNullOrEmpty(customer.FirstName))
        {
            throw new ValidationException("Customer precisa ter o primeiro nome");
        }

        return Ok($"Customer {customer.FirstName} criado com sucesso");
    }

    [HttpGet("rickandmorty")]
    public async Task<IActionResult> GetRickandMorty()
    {
        //https://rickandmortyapi.com/api/character

        using var httpClient = new HttpClient();
        var baseUrl = new Uri("https://rickandmortyapi.com");

        httpClient.BaseAddress = baseUrl;

        var response = await httpClient.GetAsync("api/character");
        var body = await response.Content.ReadAsStringAsync();

        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult>(body);

        return Ok(result);
    }
}

public class Customer
{
    public string FirstName { get; set; }
}
