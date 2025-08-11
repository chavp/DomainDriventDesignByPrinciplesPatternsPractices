using Chavp.Domain.Core.Primitives;
using Chavp.Domain.Core.Primitives.Maybe;
using Chavp.Domain.Core.Primitives.Result;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.WeatherForecast.CreateWeatherForecast;
using Orders.Application.WeatherForecast.GetWeatherForecast;
using Orders.Contracts.WeatherForecast;
using Orders.Services.Api.Infrastructure;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace Orders.Services.Api.Controllers
{
    public class WeatherForecastController : ApiController
    {
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
           : base(logger)
        {
        }

        [HttpGet("weather-forecasts")]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecastResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWeatherForecast() =>
            await Maybe<GetWeatherForecastQuery>
                .From(new GetWeatherForecastQuery())
                .Bind(query => new GetWeatherForecastQueryHandle().Handle(query))
                .Match(Ok, NotFound)
                ;

        [HttpPost("weather-forecasts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateWeatherForecast(
            WeatherForecastData? request,
            IValidator<CreateWeatherForecastRequestCommand> validator) =>
            await Result
                .Success(new CreateWeatherForecastRequestCommand(request))
                .Validate(validator)
                .Bind(command => new CreateWeatherForecastRequestCommandHandle().Handle(command))
                .Match(Ok, BadRequest)
                ;
    }
}
