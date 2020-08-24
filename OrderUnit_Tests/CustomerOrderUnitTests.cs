using Moq;
using Order.BusinessLayer.Abstract_Interface;
using Order.BusinessLayer.Concrete_Implementation;
using Order.BusinessLayer.ModelDTO;
using System;
using Xunit;

namespace OrderUnit_Tests
{
	public class CustomerOrderUnitTests
	{
		private readonly ICustomerOrder _customerOrderContext;
		private readonly Mock<ICustomerOrder> _customerOrderMock = new Mock<ICustomerOrder>();

		public CustomerOrderUnitTests(ICustomerOrder customerOrder)
		{
			_customerOrderContext = customerOrder;
		}

		[Fact]
		public void GetCustomerOrderById_ShouldGet_IfExists_NegativeTest()
		{
			// Arrange
			int customerId = 1;
			int orderId = 5;
			var custName = "Percy L";
			var customerOrderDTO = new CustomerOrderDTO
			{
				CustomerId = customerId,
				OrderId = orderId
			};

			_customerOrderMock.Setup(x => x.GetOrderByCustomerId(customerId)).Returns(customerOrderDTO);

			// Act
			var customerOrder = _customerOrderContext.GetOrderByCustomerId(customerId);

			// Assert
			Assert.Equal(expected: customerId, actual: customerOrder.CustomerId);
			Assert.Equal(expected: custName, actual: customerOrder.Name);
		}


		[Fact]
		public void GetCustomerOrderById_ShouldReturnNothing_WhenCustomerOrderDoesNotExists_NegativeTest()
		{
			// Arrange
			_customerOrderMock.Setup(x => x.GetOrderByCustomerId(It.IsAny<int>())).Returns(valueFunction: () => null);

			// Act
			var customerOrder = _customerOrderContext.GetOrderByCustomerId(10);

			// Assert
			Assert.Null(customerOrder);
		}
	}
}
