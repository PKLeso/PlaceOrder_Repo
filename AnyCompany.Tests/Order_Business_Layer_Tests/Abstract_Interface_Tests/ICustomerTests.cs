using Order.Tests.Order_Business_Layer.Concrete_Implementation;
using Order.Tests.Order_DataAccessLayer_Tests.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Tests.Order_Business_Layer_Tests.Abstract_Interface
{
	public interface ICustomerTests
	{
		IEnumerable<CustomerTests> GetCustomers();

		void AddCustomer(CustomerTests customer);


		void UpdateCustomer(CustomerTests customer);

		CustomerTests GetCustomerByID(int? id);

		void DeleteCustomer(int id);

		void Commit();
	}
}
