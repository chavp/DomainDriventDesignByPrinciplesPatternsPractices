using Chavp.Domain.Core.Primitives.Result;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Orders.CreateOrder;
using Orders.Application.WeatherForecast.CreateWeatherForecast;
using Orders.Contracts.Orders.CreateOrder;
using Orders.Contracts.WeatherForecast;
using Orders.Services.Api.Infrastructure;

namespace Orders.Services.Api.Controllers
{
    public sealed class OrdersController : ApiController
    {
        public OrdersController(ILogger<WeatherForecastController> logger)
           : base(logger)
        {
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateOrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateWeatherForecast(
            CreateOrderRequest? request) =>
            await Result
                .Success(new CreateOrderRequestCommand(request))
                .Bind(command => new CreateOrderRequestCommandHandle().Handle(command))
                .Match(Ok, BadRequest)
                ;
    }
}
