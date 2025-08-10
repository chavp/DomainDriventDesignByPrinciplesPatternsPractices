using Chavp.Application.Abstractions.Messaging;
using Chavp.Domain.Core.Primitives.Result;
using Orders.Contracts.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.WeatherForecast.CreateWeatherForecast
{
    public class CreateWeatherForecastRequestCommand : ICommand<Result>
    {
        public WeatherForecastData? Request { get; set; }

        public CreateWeatherForecastRequestCommand(WeatherForecastData? request) => Request = request;

    }
}
