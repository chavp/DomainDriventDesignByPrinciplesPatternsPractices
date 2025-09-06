using Chavp.Application.Abstractions.Messaging;
using Chavp.Domain.Core.Primitives.Result;
using Orders.Contracts.Orders.CreateOrder;
using Orders.Contracts.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Orders.CreateOrder
{
    public class CreateOrderRequestCommand : ICommand<Result<CreateOrderResponse>>
    {
        public CreateOrderRequest? Request { get; set; }

        public CreateOrderRequestCommand(CreateOrderRequest? request) => Request = request;
    }
}
