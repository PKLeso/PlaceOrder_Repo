using Moq;
using System;
using Xunit;
using 

namespace Order_Tests
{
	public class CustomerOrder_Tests
	{
		[Fact]
		public void GetCustomerOrderById_ShouldGet_WhenExists()
		{
			var _customerOrder = new Mock<ICustomerOrder>();
		}
	}
}
