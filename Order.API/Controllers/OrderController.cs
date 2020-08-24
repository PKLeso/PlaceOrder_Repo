using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.API.DTOModel;
using Order.BusinessLayer.Abstract_Interface;

namespace Order.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrder _order;
		public OrderController(IOrder order)
		{
			_order = order;
		}

		[HttpGet]
		[Route("GetOrders")]
		public IEnumerable<OrderDTO> GetOrders()
		{
			var orderList = _order.GetOrders().ToList();

			var orders = orderList.Select(a => new OrderDTO()
			{
				OrderId = a.OrderId,
				Amount = a.Amount,
				VAT = a.VAT,
				CustomerId = a.CustomerId
			}).ToList();

			return orders;
		}


		[HttpGet]
		[Route("GetOrderById")]
		public OrderDTO GetOrderById(int orderId)
		{
			var order = _order.GetOrderByID(orderId);

			var orderView = new OrderDTO()
			{
				OrderId = order.OrderId,
				CustomerId = order.CustomerId,
				Amount = order.Amount,
				VAT = order.VAT
			};

			return orderView;
		}

		[HttpPost]
		[Route("AddAnOrder")]

		public HttpResponseMessage AddAnOrder([FromBody] Order_DataAccessLayer.Model.Order order)
		{
			Order_DataAccessLayer.Model.Order addAnOrder = new Order_DataAccessLayer.Model.Order()
			{
				Amount = order.Amount,
				VAT = order.VAT,
				CustomerId = order.CustomerId // can be extracted from a seesion variable of a logged in user
			};
			_order.AddOrder(addAnOrder);

			return new HttpResponseMessage(HttpStatusCode.Created);
		}

		[HttpDelete]
		[Route("DeleteOrder")]
		public HttpResponseMessage DeleteOrder(int id)
		{
			_order.DeleteOrder(id);
			_order.Commit();

			return new HttpResponseMessage(HttpStatusCode.OK);
		}
	}
}
