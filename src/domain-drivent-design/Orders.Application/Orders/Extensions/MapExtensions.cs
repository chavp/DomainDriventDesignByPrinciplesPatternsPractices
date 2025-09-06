using Chavp.Domain.Core.Primitives.Result;
using Orders.Contracts.Orders.CreateOrder;
using Orders.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Orders.Extensions
{
    public static class MapExtensions
    {
        public static CreateOrderResponse Map(this Result<Order> o) => new CreateOrderResponse
        {
            OrderDate = o.Value.OrderDate,
            OrderNumber = o.Value.Number,
            ShippingAddressName = o.Value.ShippingPostalAddress.Name,
            ShippingAddressProvince = o.Value.ShippingPostalAddress.Province,
        };
    }
}
