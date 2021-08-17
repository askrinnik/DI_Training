using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MediatR_WebApplication.WeatherForecastApp
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly List<WeatherForecast> _list;
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastRepository()
        {
            var rng = new Random();
            _list = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToList();
        }

        public IEnumerable<WeatherForecast> Get()
        {
            return _list.ToImmutableArray();
        }
    }
}
