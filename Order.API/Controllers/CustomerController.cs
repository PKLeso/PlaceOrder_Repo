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
using Order_DataAccessLayer.Model;

namespace Order.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomer _customer;
		public CustomerController(ICustomer customer)
		{
			_customer = customer;
		}

		[HttpGet]
		[Route("GetCustomer")]
		public IEnumerable<CustomerDTO> GetCustomer()
		{
			var customerList = _customer.GetCustomers().ToList();

			var customer = customerList.Select(a => new CustomerDTO() { 
			
				CustomerId = a.CustomerId,
				Country = a.Country,
				DateOfBirth = a.DateOfBirth,
				Name = a.Name
			}).ToList();

			return customer;
		}

		[HttpGet]
		[Route("GetCustomerById")]
		public CustomerDTO GetCustomerById(int customerId)
		{
			var customer = _customer.GetCustomerByID(customerId);

			var customerView = new CustomerDTO()
			{
				Name = customer.Name,
				CustomerId = customer.CustomerId,
				Country = customer.Country,
				DateOfBirth = customer.DateOfBirth
			};

			return customerView;
		}


		[HttpPost]
		[Route("AddCustomer")]

		public HttpResponseMessage AddCustomer([FromBody] Customer customer)
		{
			Customer addCustomer = new Customer()
			{
				Name = customer.Name,
				Country = customer.Country,
				DateOfBirth = customer.DateOfBirth
			};
			_customer.AddCustomer(addCustomer);

			return new HttpResponseMessage(HttpStatusCode.Created);
		}


		[HttpDelete]
		[Route("DeleteCustomer")]
		public HttpResponseMessage DeleteCustomer(int id)
		{
			_customer.DeleteCustomer(id);
			_customer.Commit();

			return new HttpResponseMessage(HttpStatusCode.OK);
		}
	}
}
