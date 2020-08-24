using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.DTOModel
{
	public class OrderDTO
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public decimal VAT { get; set; }
        public int CustomerId { get; set; }
    }
}
