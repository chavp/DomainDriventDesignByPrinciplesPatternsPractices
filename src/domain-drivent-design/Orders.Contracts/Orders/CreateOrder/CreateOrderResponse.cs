using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Contracts.Orders.CreateOrder
{
    public sealed class CreateOrderResponse
    {
        public int OrderNumber { get; set; }
        public DateOnly OrderDate { get; set; }
        public string? ShippingAddressName { get; set; }
        public string? ShippingAddressProvince { get; set; }
    }
}
