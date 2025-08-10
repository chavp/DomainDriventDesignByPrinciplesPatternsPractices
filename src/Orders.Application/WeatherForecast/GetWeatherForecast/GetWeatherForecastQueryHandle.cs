using Chavp.Application.Abstractions.Messaging;
using Chavp.Domain.Core.Primitives.Maybe;
using Chavp.Domain.Core.Primitives.Result;
using Orders.Contracts.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.WeatherForecast.GetWeatherForecast
{
    public sealed class GetWeatherForecastQueryHandle : IQueryHandler<GetWeatherForecastQuery, Maybe<WeatherForecastResponse>>
    {
        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public GetWeatherForecastQueryHandle() { }

        public async Task<Maybe<WeatherForecastResponse>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException("test");

            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecastData
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            if (!result.Any()) return Maybe<WeatherForecastResponse>.None;

            var resp = new WeatherForecastResponse
            {
                WeatherForecasts = result
            };

            return resp;
        }
    }
}
