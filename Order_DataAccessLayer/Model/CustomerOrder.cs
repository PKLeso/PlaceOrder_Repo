using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_DataAccessLayer.Model
{
	public class CustomerOrder
	{
        public int CustomerId { get; set; }
        public string Country { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
