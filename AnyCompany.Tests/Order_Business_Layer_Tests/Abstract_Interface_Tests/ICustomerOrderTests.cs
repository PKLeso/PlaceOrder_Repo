using Order.Tests.ModelDTO_Tests;
using Order.Tests.Order_Business_Layer.Concrete_Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Tests.Order_Business_Layer_Tests.Abstract_Interface
{
	public interface ICustomerOrderTests
	{
		IEnumerable<CustomerOrderDTOTests> GetAllCustomerOrders();

		void GetOrderByCustomerId(int CustomerId);
	}
}
