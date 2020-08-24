using System.Collections.Generic;

namespace Order.BusinessLayer.Abstract_Interface
{
	public interface IOrder
	{
		IEnumerable<Order_DataAccessLayer.Model.Order> GetOrders();

		Order_DataAccessLayer.Model.Order AddOrder(Order_DataAccessLayer.Model.Order order);


		void UpdateOrder(Order_DataAccessLayer.Model.Order order);

		Order_DataAccessLayer.Model.Order GetOrderByID(int? id);

		void DeleteOrder(int id);

		void Commit();
	}
}
