using Moq;
using Order.Tests.Order_Business_Layer_Tests.Abstract_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order.Tests.Order_Business_Layer.Concrete_Implementation
{
	public class OrderServiceTests
	{
		private readonly Order.Tests.Order_DataAccessLayer_Tests.Model.Order _orderServiceTest;
		private readonly Mock<IOrder> _orderDbMock = new Mock<IOrder>();

		public OrderServiceTests()
		{
			_orderServiceTest = new Order_DataAccessLayer_Tests.Model.Order(_orderDbMock.Object);
		}

		public void AddOrder(Order.Tests.Order_DataAccessLayer_Tests.Model.Order order)
		{
			throw new NotImplementedException();
		}

		public void Commit()
		{
			throw new NotImplementedException();
		}

		public void DeleteOrder(int id)
		{
			throw new NotImplementedException();
		}

		public Order.Tests.Order_DataAccessLayer_Tests.Model.Order GetOrderByID(int? id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Order.Tests.Order_DataAccessLayer_Tests.Model.Order> GetOrders()
		{
			throw new NotImplementedException();
		}

		public void UpdateOrder(Order.Tests.Order_DataAccessLayer_Tests.Model.Order order)
		{
			throw new NotImplementedException();
		}
	}
}
