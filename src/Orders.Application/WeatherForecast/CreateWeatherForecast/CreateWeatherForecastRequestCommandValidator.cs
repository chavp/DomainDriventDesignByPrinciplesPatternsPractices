using Chavp.Domain.Core.Primitives;
using EventReminder.Application.Core.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.WeatherForecast.CreateWeatherForecast
{
    public class CreateWeatherForecastRequestCommandValidator 
        : AbstractValidator<CreateWeatherForecastRequestCommand>
    {
        public CreateWeatherForecastRequestCommandValidator()
        {
            RuleFor(x => x)
                .Null()
                .WithError(new Error(
                "CreateWeatherForecastRequest",
                "The WeatherForecastData is not null."));
            RuleFor(x => x.Request)
                .Null()
                .WithError(new Error(
                "CreateWeatherForecastRequest.WeatherForecastData",
                "The WeatherForecastData is not null."));
        }
    }
}
