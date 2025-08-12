using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Contracts.Orders.CreateOrder
{
    public sealed class CreateOrderRequest
    {
        public string? ShippingAddressName { get; set; }
        public string? ShippingAddressProvince { get; set; }
    }
}
