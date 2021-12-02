using CRM.App.Abstract;
using CRM.App.Managers;
using CRM.Domain.Entity;
using Moq;
using System;
using Xunit;

namespace CRM.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arange
            Customer customer = new Customer(1, "Lasek", "Maciej", 6543210);
            var mock = new Mock<IService<Customer>>();
            mock.Setup(s => s.GetItemById(1)).Returns(customer);
            var manager = new CustomerManager();
            // Act


            //Assert
        }
    }
}
