using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.API.DTOModel;
using Order.BusinessLayer.Abstract_Interface;

namespace Order.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerOrderController : ControllerBase
	{
		private readonly ICustomerOrder _customerOrder;
		public CustomerOrderController(ICustomerOrder customerOrder)
		{
			_customerOrder = customerOrder;
		}

		[HttpGet]
		[Route("GetAllCustomerOrders")]
		public IEnumerable<CustomerOrderDTO> GetAllCustomerOrders()
		{
			var customerOrderList = _customerOrder.GetAllCustomerOrders().ToList();

			var customerOrder = customerOrderList.Select(a => new CustomerOrderDTO()
			{ 
				Name = a.Name,
				CustomerId = a.CustomerId,
				Country = a.Country,
				DateOfBirth = a.DateOfBirth,
				OrderId = a.OrderId,
				Amount = a.Amount,
				VAT = a.VAT				
			}).ToList();

			return customerOrder;
		}

		[HttpGet]
		[Route("GetCustomerOrderByCustomerId")]
		public CustomerOrderDTO GetCustomerOrderByCustomerId(int customerId)
		{
			var customerOrder = _customerOrder.GetOrderByCustomerId(customerId);

			var customerOrderView = new CustomerOrderDTO()
			{
				Name = customerOrder.Name,
				CustomerId = customerOrder.CustomerId,
				Country = customerOrder.Country,
				DateOfBirth = customerOrder.DateOfBirth,
				OrderId = customerOrder.OrderId,
				Amount = customerOrder.Amount,
				VAT = customerOrder.VAT
			};

			return customerOrderView;
		}
	}
}
