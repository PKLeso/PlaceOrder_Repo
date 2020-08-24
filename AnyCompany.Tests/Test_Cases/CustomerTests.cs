using Moq;
using Order.Tests.Order_Business_Layer_Tests.Abstract_Interface;
using Order.Tests.Order_DataAccessLayer_Tests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Order.Tests.Order_Business_Layer.Concrete_Implementation
{
	public class CustomerTests
	{
		private readonly Customer _customerServiceTest;
		private readonly Mock<ICustomerTests> _orderDbMock = new Mock<ICustomerTests>();

		public CustomerTests()
		{
			_customerServiceTest = new Customer(_orderDbMock.Object);
		}


		IEnumerable<Customer> GetCustomers()
		{
			throw new NotImplementedException();
		}

		public void AddCustomer(Customer customer)
		{
			throw new NotImplementedException();
		}

		public void UpdateCustomer(Customer customer)
		{
			throw new NotImplementedException();
		}

		[Fact]
		public Customer GetCustomerByID_ShouldReturnCustomer_WhenCustomerExists()
		{
			throw new NotImplementedException();
		}

		public void DeleteCustomer(int id)
		{
			throw new NotImplementedException();
		}

		public void Commit()
		{
			throw new NotImplementedException();
		}
	}
}
