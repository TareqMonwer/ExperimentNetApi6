using ExperimentNetApi6.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExperimentNetApi6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherRepository _weather_service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherRepository weather_svc)
        {
            _logger = logger;
            _weather_service = weather_svc;
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
        public IActionResult CreateWeatherRecord()
        {
            _weather_service.CreateWeather();
            return Ok("Resource Created");
        }
    }
}