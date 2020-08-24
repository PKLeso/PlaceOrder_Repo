using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_DataAccessLayer.Model
{
	public class Order
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public decimal VAT { get; set; }
        public int CustomerId { get; set; }
    }
}
