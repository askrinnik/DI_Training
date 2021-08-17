using System.Collections.Generic;

namespace MediatR_WebApplication.WeatherForecastApp
{
    public interface IWeatherForecastRepository
    {
        IEnumerable<WeatherForecast> Get();
    }
}