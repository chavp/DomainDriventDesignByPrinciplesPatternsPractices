using Chavp.Domain.Core.Primitives;
using Chavp.Domain.Core.Primitives.Maybe;
using Chavp.Domain.Core.Primitives.Result;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.WeatherForecast.CreateWeatherForecast;
using Orders.Application.WeatherForecast.GetWeatherForecast;
using Orders.Contracts.WeatherForecast;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace Orders.Services.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //protected IActionResult BadRequest(Error error) => BadRequest(new ApiErrorResponse(new[] { error }));
        protected new IActionResult Ok(object value) => base.Ok(value);
        protected IActionResult BadRequest(List<Error> errors)
        {
            var details = new List<string>();
            foreach (var error in errors) {
                details.Add($"{error.Code}:{error.Message}");
            }

            var prob1 = base.Problem(
                statusCode: StatusCodes.Status400BadRequest,
                title: "Bad Request",
                type: "https://datatracker.ietf.org/doc/html/rfc7231#sectio-6.6.1",
                detail: string.Join(", ", details)
                );
            
            //prob1.Value = new {
            //    status = StatusCodes.Status400BadRequest,
            //    title = "Bad Request",
            //    type = "https://datatracker.ietf.org/doc/html/rfc7231#sectio-6.6.1",
            //    errors = errors 
            //};
            return prob1;
        }

        protected new IActionResult NotFound() => base.NotFound();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecastResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWeatherForecast() =>
            await Maybe<GetWeatherForecastQuery>
                .From(new GetWeatherForecastQuery())
                .Bind(query => new GetWeatherForecastQueryHandle().Handle(query))
                .Match(Ok, NotFound)
                ;

        [HttpPost(Name = "CreateWeatherForecast")]
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
