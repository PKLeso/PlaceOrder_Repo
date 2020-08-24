using Order_DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.BusinessLayer.Abstract_Interface
{
	public interface ICustomer
	{
		IEnumerable<Customer> GetCustomers();

		void AddCustomer(Customer customer);


		void UpdateCustomer(Customer customer);

		Customer GetCustomerByID(int? id);

		void DeleteCustomer(int id);

		void Commit();
	}
}
