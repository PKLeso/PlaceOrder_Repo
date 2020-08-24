using Order.Tests.Order_Business_Layer_Tests.Abstract_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Tests.Order_DataAccessLayer_Tests.Model
{
	public class OrderTests
    {
		public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public decimal VAT { get; set; }
        public int CustomerId { get; set; }
    }
}
