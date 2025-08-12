using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Orders
{
    public class PostalAddress
    {
        internal PostalAddress() { }

        public string? Name { get; init; }
        public string? Province { get; init; }
    }
}
