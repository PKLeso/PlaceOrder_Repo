using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Tests.Order_DataAccessLayer_Tests.Model
{
	public class CustomerOrderTests
    {
        public int CustomerId { get; set; }
        public string Country { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Name { get; set; }

        public ICollection<OrderTests> Orders { get; set; }
    }
}
