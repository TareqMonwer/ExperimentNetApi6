using Contracts;
using ExperimentNetApi6.Data;
using ExperimentNetApi6.Dtos;
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

        private readonly INLoggerManager _logger;
        private readonly IWeatherRepository _weather_service;

        public WeatherForecastController(INLoggerManager logger, IWeatherRepository weather_svc)
        {
            _logger = logger;
            _weather_service = weather_svc;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInfo("---LoggerService: Loginfo");
            _logger.LogDebug("----LoggerService: LogDebug");
            _logger.LogWarn("---LoggerService: LogWarning");
            _logger.LogError("---LoggerService: LogError");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public IActionResult CreateWeatherRecord([FromBody]WeatherForecast weatherForecast)
        {
            _weather_service.CreateWeather();
            return Ok("Resource Created");
        }

        [HttpGet]
        [Route("fromDb/")]
        public ActionResult<ICollection<Weather>> GetAllFromDB()
        {
            return Ok(_weather_service.GetAll());
        }

        [HttpPut("{id}")]
        public ActionResult<Weather> Update(int id, [FromBody]WeatherForecast weatherIn)
        {
            var weather = _weather_service.GetWeatherById(id);

            if (weather != null)
            {
                _weather_service.UpdateWeather(id, weather, weatherIn);
                return NoContent();
            }
            return NotFound();
        }
    }
}