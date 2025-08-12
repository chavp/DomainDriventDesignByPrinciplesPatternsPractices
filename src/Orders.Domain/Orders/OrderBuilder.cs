using Chavp.Domain.Core.Primitives.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Orders
{
    public class OrderBuilder
    {
        private int _number;
        private DateOnly _orderDate;

        private PostalAddressBuilder _postalAddressBuilder = PostalAddressBuilder.Empty;

        private OrderBuilder() { }

        public static OrderBuilder Empty => new OrderBuilder();

        public OrderBuilder Number(int number)
        {
            _number = number;
            return this;
        }

        public OrderBuilder OrderDate(DateOnly orderDate)
        {
            _orderDate = orderDate;
            return this;
        }

        public OrderBuilder ShippingPostalAddress(Action<PostalAddressBuilder> action)
        {
            action(_postalAddressBuilder);
            return this;
        }

        public Result<Order> Build() => new Order
        {
            Number = _number,
            OrderDate = _orderDate,
            ShippingPostalAddress = _postalAddressBuilder.Build(),
        };
    }
}
