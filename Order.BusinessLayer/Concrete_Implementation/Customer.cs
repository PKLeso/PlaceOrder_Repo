using Order.BusinessLayer.Abstract_Interface;
using Order_DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Order.BusinessLayer.Concrete_Implementation
{
	public class Customer : ICustomer
	{
		private OrderContext _context;
		public Customer(OrderContext context)
		{
			_context = context;
		}

		public void AddCustomer(Order_DataAccessLayer.Model.Customer customer)
		{
			try
			{
				_context.Customers.Add(customer);
				_context.SaveChanges();
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
			{
				Exception raise = dbEx;
				foreach (var validationErrors in dbEx.EntityValidationErrors)
				{
					foreach (var validationError in validationErrors.ValidationErrors)
					{
						string message = string.Format("{0}:{1}",
							validationErrors.Entry.Entity.ToString(),
							validationError.ErrorMessage);
						raise = new InvalidOperationException(message, raise);
					}
				}
				throw raise;
			}
		}

		public void DeleteCustomer(int id)
		{
			try
			{
				var customer = _context.Customers.Find(id);
				_context.Customers.Remove(customer);
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
			{
				Exception raise = dbEx;
				foreach (var validationErrors in dbEx.EntityValidationErrors)
				{
					foreach (var validationError in validationErrors.ValidationErrors)
					{
						string message = string.Format("{0}:{1}",
							validationErrors.Entry.Entity.ToString(),
							validationError.ErrorMessage);
						raise = new InvalidOperationException(message, raise);
					}
				}
				throw raise;
			}
		}

		public Order_DataAccessLayer.Model.Customer GetCustomerByID(int? id)
		{
			try
			{
				Order_DataAccessLayer.Model.Customer entity = _context.Customers.FirstOrDefault(x => x.CustomerId == id);
				if (entity != null)
					_context.Customers.Find(id);
				else
					throw new Exception("Customer not found");
				return entity;
			}

			catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
			{
				Exception raise = dbEx;
				foreach (var validationErrors in dbEx.EntityValidationErrors)
				{
					foreach (var validationError in validationErrors.ValidationErrors)
					{
						string message = string.Format("{0}:{1}",
							validationErrors.Entry.Entity.ToString(),
							validationError.ErrorMessage);
						raise = new InvalidOperationException(message, raise);
					}
				}
				throw raise;
			}
		}

		public IEnumerable<Order_DataAccessLayer.Model.Customer> GetCustomers()
		{
			try
			{
				var customerList = _context.Customers.ToList();
				return customerList;
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
			{
				Exception raise = dbEx;
				foreach (var validationErrors in dbEx.EntityValidationErrors)
				{
					foreach (var validationError in validationErrors.ValidationErrors)
					{
						string message = string.Format("{0}:{1}",
							validationErrors.Entry.Entity.ToString(),
							validationError.ErrorMessage);
						raise = new InvalidOperationException(message, raise);
					}
				}
				throw raise;
			}
		}

		public void UpdateCustomer(Order_DataAccessLayer.Model.Customer customer)
		{
			try
			{
				_context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				Commit();
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
			{
				Exception raise = dbEx;
				foreach (var validationErrors in dbEx.EntityValidationErrors)
				{
					foreach (var validationError in validationErrors.ValidationErrors)
					{
						string message = string.Format("{0}:{1}",
							validationErrors.Entry.Entity.ToString(),
							validationError.ErrorMessage);
						raise = new InvalidOperationException(message, raise);
					}
				}
				throw raise;
			}
		}

		public void Commit()
		{
			try
			{
				_context.SaveChanges();
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
			{
				Exception raise = dbEx;
				foreach (var validationErrors in dbEx.EntityValidationErrors)
				{
					foreach (var validationError in validationErrors.ValidationErrors)
					{
						string message = string.Format("{0}:{1}",
							validationErrors.Entry.Entity.ToString(),
							validationError.ErrorMessage);
						raise = new InvalidOperationException(message, raise);
					}
				}
				throw raise;
			}
		}
	}
}
