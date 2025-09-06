using Chavp.Application.Abstractions.Messaging;
using Chavp.Domain.Core.Primitives.Maybe;
using Chavp.Domain.Core.Primitives.Result;
using Orders.Application.Orders.Extensions;
using Orders.Application.WeatherForecast.CreateWeatherForecast;
using Orders.Contracts.Orders.CreateOrder;
using Orders.Contracts.WeatherForecast;
using Orders.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Orders.CreateOrder
{
    public class CreateOrderRequestCommandHandle
         : ICommandHandler<CreateOrderRequestCommand, Result<CreateOrderResponse>>
    {
        private OrderBuilder _orderBuilder = OrderBuilder.Empty;

        private static int OrderNumberSeq = 0;

        public async Task<Result<CreateOrderResponse>> Handle(CreateOrderRequestCommand command, CancellationToken cancellationToken = default)
        {
            var orderResponse = _orderBuilder
                            .Number(++OrderNumberSeq)
                            .OrderDate(DateOnly.FromDateTime(DateTime.Now))
                            .ShippingPostalAddress(b => b
                                .Name(command.Request.ShippingAddressName)
                                .Province(command.Request.ShippingAddressProvince)
                            )
                            .Build()
                            .Map();
            return orderResponse;
        }
    }
}
