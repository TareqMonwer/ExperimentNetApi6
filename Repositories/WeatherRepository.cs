using ExperimentNetApi6.Data;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ExperimentNetApi6.Services
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly ExperimentNetApi6Context _context;

        public WeatherRepository(ExperimentNetApi6Context context)
        {
            _context = context;
        }

        public void CreateWeather()
        {
            _context.Weather.Add(new Weather() { DateTime = DateTime.UtcNow, Summary = "Warm", TemperatureF = 1, TemperatureC = 1, SearchCount = "0" });
            _context.SaveChanges();
        }
    }
}