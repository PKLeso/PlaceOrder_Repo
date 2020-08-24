using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_DAL.Model
{
	public class CustomerOrder
	{
        public int CustomerId { get; set; }
        public string Country { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order_DAL.Model.Order> Orders { get; set; }
    }
}
