using Moq;
using Order.BusinessLayer.Abstract_Interface;
using Order.BusinessLayer.Concrete_Implementation;
using System;
using Xunit;

namespace OrderUnit_Tests
{
	public class OrderUnitTests
	{
		private readonly IOrder _orderContext;
		private readonly Mock<IOrder> _orderMock = new Mock<IOrder>();

		public OrderUnitTests()
		{
			_orderContext = _orderMock.Object;
		}

		[Fact]
		public void GetOrderById_ShouldGet_IfExists()
		{
			// Arrange
			int orderId = 21;
			var amount = 50;
			var orderDTO = new Order_DataAccessLayer.Model.Order
			{
				OrderId = orderId,
				Amount = amount
			};

			_orderMock.Setup(x => x.GetOrderByID(orderId)).Returns(orderDTO);

			// Act
			Order_DataAccessLayer.Model.Order order = _orderContext.GetOrderByID(orderId);

			// Assert
			Assert.Equal(expected: orderId, actual: order.OrderId);
			Assert.Equal(expected: amount, actual: order.Amount);
		}


		[Fact]
		public void GetOrderById_ShouldReturnNothing_WhenOrderDoesNotExists()
		{
			// Arrange
			_orderMock.Setup(x => x.GetOrderByID(It.IsAny<int>())).Returns(valueFunction: () => null);

			// Act
			Order_DataAccessLayer.Model.Order order = _orderContext.GetOrderByID(16);

			// Assert
			Assert.Null(order);
		}

		[Fact]
		public void AddOrder_ShouldFail()
		{
			// Arrange
			int orderId = 21;
			int customerId = 6;
			var amount = 50;
			decimal vat = new decimal(0.15);
			var orderDTO = new Order_DataAccessLayer.Model.Order
			{
				OrderId = orderId,
				Amount = amount,
				CustomerId = customerId,
				VAT = vat
			};

			_orderMock.Setup(x => x.AddOrder(orderDTO)).Verifiable();

			// Act
			Order_DataAccessLayer.Model.Order result = _orderContext.AddOrder(orderDTO);

			// Assert
			Assert.Equal(expected: result, orderDTO);
		}


	}
}
