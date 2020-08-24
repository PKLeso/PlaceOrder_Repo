using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Order.BusinessLayer.Abstract_Interface;
using Order_DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using Order.BusinessLayer.ModelDTO;

namespace Order.BusinessLayer.Concrete_Implementation
{
	public class CustomerOrder : ICustomerOrder
	{
		private OrderContext _context;
		public CustomerOrder(OrderContext context)
		{
			_context = context;
		}

		IEnumerable<CustomerOrderDTO> ICustomerOrder.GetAllCustomerOrders()
		{
			try
			{
				var Orders = _context.Orders.Where(x => x.CustomerId > 0).ToList();

				var customerOrder = _context.Customers.Include(c => c.Orders).Where(x => x.CustomerId > 0).ToList();

				var  custOrd = customerOrder.Select(a => new CustomerOrderDTO()
				{
					Name = a.Name,
					Country = a.Country,
					CustomerId = a.CustomerId,
					DateOfBirth = a.DateOfBirth,
					OrderId = a.Orders.FirstOrDefault().OrderId,
					Amount = a.Orders.FirstOrDefault().Amount,
					VAT = a.Orders.FirstOrDefault().VAT
					
				}).ToList().OrderBy(a => a.CustomerId);

				return custOrd;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		CustomerOrderDTO ICustomerOrder.GetOrderByCustomerId(int customerId)
		{
			try
			{
				var customerOrder = _context.Customers.Include(o => o.Orders).Where(x => x.CustomerId == customerId).FirstOrDefault();

				var custOrd = new CustomerOrderDTO()
				{
					Name = customerOrder.Name,
					Country = customerOrder.Country,
					CustomerId = customerOrder.CustomerId,
					DateOfBirth = customerOrder.DateOfBirth,
					OrderId = customerOrder.Orders.FirstOrDefault().OrderId,
					Amount = customerOrder.Orders.FirstOrDefault().Amount,
					VAT = customerOrder.Orders.FirstOrDefault().VAT

				};

				return custOrd;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}
