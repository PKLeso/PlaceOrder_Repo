using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Order.Tests.Order_Business_Layer_Tests.Abstract_Interface;
using Order.Tests.ModelDTO_Tests;
using Moq;

namespace Order.Tests.Order_Business_Layer.Concrete_Implementation
{
	public class CustomerOrderTests
	{

		private readonly CustomerOrder _customerOrderServiceTest;
		private readonly Mock<ICustomerOrderTests> _customerOrderMock = new Mock<ICustomerOrderTests>();

		public CustomerOrderTests(ICustomerOrderTests obj)
		{
			_customerOrderServiceTest = new CustomerOrderTests();
		}

		public IEnumerable<CustomerOrderDTOTests> GetAllCustomerOrders()
		{
			// Arrange


			// Act


			// Assert
		}

		public CustomerOrderDTOTests GetOrderByCustomerId_ShouldReturnCustomerOrder_WhenExists()
		{
			// Arrange
			var customerId = 1;

			// Act
			var customer = _customerOrderServiceTest.GetOrderByCustomerId(customerId);


			// Assert
		}
	}
}
