using System;
using System.Collections.Generic;
using System.Text;
using Order.BusinessLayer.ModelDTO;
using Order_DataAccessLayer;

namespace Order.BusinessLayer.Abstract_Interface
{
	public interface ICustomerOrder
	{
		IEnumerable<CustomerOrderDTO> GetAllCustomerOrders();

		CustomerOrderDTO GetOrderByCustomerId(int CustomerId);
	}
}
