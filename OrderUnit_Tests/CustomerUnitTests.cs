using Moq;
using Order.BusinessLayer.Abstract_Interface;
using Order.BusinessLayer.Concrete_Implementation;
using System;
using Xunit;

namespace OrderUnit_Tests
{
	public class CustomerUnitTests
	{
		private readonly ICustomer _customerContext;
		private readonly Mock<ICustomer> _customerMock = new Mock<ICustomer>();

		public CustomerUnitTests()
		{
			_customerContext = _customerMock.Object;
		}

		[Fact]
		public void GetCustomerById_ShouldGet_IfExists()
		{
			// Arrange
			int customerId = 1;
			var custName = "Percy L";
			var customerDTO = new Order_DataAccessLayer.Model.Customer
			{
				CustomerId = customerId,
				Name = custName
			};

			_customerMock.Setup(x => x.GetCustomerByID(customerId)).Returns(customerDTO);

			// Act
			Order_DataAccessLayer.Model.Customer customer = _customerContext.GetCustomerByID(customerId);

			// Assert
			Assert.Equal(expected: customerId, actual: customer.CustomerId);
			Assert.Equal(expected: custName, actual: customer.Name);
		}


		[Fact]
		public void GetCustomerById_ShouldReturnNothing_WhenCustomerDoesNotExists()
		{
			// Arrange
			_customerMock.Setup(x => x.GetCustomerByID(It.IsAny<int>())).Returns(valueFunction: () => null);

			// Act
			Order_DataAccessLayer.Model.Customer customer = _customerContext.GetCustomerByID(1);

			// Assert
			Assert.Null(customer);
		}
	}
}
