using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Orders
{
    public class PostalAddressBuilder
    {
        private string? _name;
        private string? _province;

        private PostalAddressBuilder() { }

        public static PostalAddressBuilder Empty => new PostalAddressBuilder();

        public PostalAddressBuilder Name(string? name)
        {
            _name = name;
            return this;
        }
        public PostalAddressBuilder Province(string? province)
        {
            _province = province;
            return this;
        }

        public PostalAddress Build() => new PostalAddress
        {
            Name = _name,
            Province = _province
        };
    }
}
