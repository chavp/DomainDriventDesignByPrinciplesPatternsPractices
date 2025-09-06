using Chavp.Application.Abstractions.Messaging;
using Chavp.Domain.Core.Primitives.Maybe;
using Orders.Contracts.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.WeatherForecast.GetWeatherForecast
{
    public sealed class GetWeatherForecastQuery : IQuery<Maybe<WeatherForecastResponse>>
    {
    }
}
