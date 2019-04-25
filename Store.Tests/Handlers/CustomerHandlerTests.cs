using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Enums;
using Store.Domain.StoreContext.Handlers;
using Store.Tests.Fakes;

namespace Store.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Ricardo";
            command.LastName = "Silva";
            command.Document = "13230609018";
            command.Email = "ricardocavalcantesilva@gmail.com";
            command.Phone = "5521999999999";

            Assert.AreEqual(true, command.Valid());

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
        }
    }
}
