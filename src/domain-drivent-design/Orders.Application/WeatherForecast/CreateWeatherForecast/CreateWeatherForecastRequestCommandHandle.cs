using Chavp.Application.Abstractions.Common;
using Chavp.Application.Abstractions.Messaging;
using Chavp.Domain.Core.Primitives.Maybe;
using Chavp.Domain.Core.Primitives.Result;
using Orders.Contracts.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.WeatherForecast.CreateWeatherForecast
{
    public class CreateWeatherForecastRequestCommandHandle 
        : ICommandHandler<CreateWeatherForecastRequestCommand, Result>
    {
        private static List<WeatherForecastData> _weatherForecastData = [];
        public async Task<Result> Handle(CreateWeatherForecastRequestCommand request, CancellationToken cancellationToken = default)
        {
            _weatherForecastData.Add(request.Request);

            return Result.Success();
        }
    }
}
