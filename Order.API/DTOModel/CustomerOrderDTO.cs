using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.DTOModel
{
	public class CustomerOrderDTO
    {
        public int CustomerId { get; set; }

        public string Country { get; set; }

        public System.DateTime DateOfBirth { get; set; }

        public string Name { get; set; }

        public int OrderId { get; set; }

        public decimal Amount { get; set; }

        public decimal VAT { get; set; }
    }
}
