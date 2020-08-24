using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Tests.ModelDTO_Tests
{
	public class CustomerOrderDTOTests
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
