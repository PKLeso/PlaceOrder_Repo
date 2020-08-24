using Order.BusinessLayer.Abstract_Interface;
using Order_DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Order.BusinessLayer.Concrete_Implementation
{
	public class Order : IOrder
	{
		private OrderContext _context;
		public Order(OrderContext context)
		{
			_context = context;
		}

		public void AddOrder(Order_DataAccessLayer.Model.Order order)
		{
			try
			{
				_context.Orders.Add(order);
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

		public void DeleteOrder(int id)
		{
			try
			{
				var order = _context.Orders.Find(id);
				_context.Orders.Remove(order);
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

		public Order_DataAccessLayer.Model.Order GetOrderByID(int? id)
		{
			try
			{
				Order_DataAccessLayer.Model.Order entity = _context.Orders.FirstOrDefault(x => x.OrderId == id);
				if (entity != null)
					_context.Orders.Find(id);
				else
					throw new Exception("Order not found");
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

		public IEnumerable<Order_DataAccessLayer.Model.Order> GetOrders()
		{
			try
			{
				var orderList = _context.Orders.ToList();
				return orderList;
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

		public void UpdateOrder(Order_DataAccessLayer.Model.Order order)
		{
			try
			{
				_context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
