using Order.Tests.Order_Business_Layer_Tests.Abstract_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Tests.Order_DataAccessLayer_Tests.Model
{
	public class CustomerTests
    {
		public int CustomerId { get; set; }
        public string Country { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Name { get; set; }
    }
}
