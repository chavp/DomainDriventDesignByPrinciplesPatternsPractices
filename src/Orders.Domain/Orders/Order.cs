using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Orders
{
    public class Order
    {
        internal Order() { }

        public int Number { get; init; }
        public DateOnly OrderDate { get; init; }

        public PostalAddress? ShippingPostalAddress { get; init; }
    }
}
