using System.Collections.Generic;
using Order.Tests;

namespace Order.Tests.Order_Business_Layer_Tests.Abstract_Interface
{
	public interface IOrderTests
	{
		IEnumerable<Order.Tests.Order_DataAccessLayer_Tests.Model.OrderTests> GetOrders();

		void AddOrder(Order.Tests.Order_DataAccessLayer_Tests.Model.OrderTests order);


		void UpdateOrder(Order.Tests.Order_DataAccessLayer_Tests.Model.OrderTests order);

		Order.Tests.Order_DataAccessLayer_Tests.Model.OrderTests GetOrderByID(int? id);

		void DeleteOrder(int id);

		void Commit();
	}
}
