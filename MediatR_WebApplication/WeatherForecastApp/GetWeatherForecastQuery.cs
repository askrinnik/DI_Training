using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatR_WebApplication.WeatherForecastApp
{
    public class GetWeatherForecastQuery: IRequest<IEnumerable<WeatherForecast>> {}

    public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>
    {
        private readonly IWeatherForecastRepository _repo;

        public GetWeatherForecastHandler(IWeatherForecastRepository repo) => _repo = repo;

        public Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken) => Task.FromResult(_repo.Get());
    }
}