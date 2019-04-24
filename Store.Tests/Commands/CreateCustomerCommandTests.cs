using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Enums;

namespace Store.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Ricardo";
            command.LastName = "Silva";
            command.Document = "13230609018";
            command.Email = "ricardocavalcantesilva@gmail.com";
            command.Phone = "5521999999999";

            Assert.AreEqual(true, command.Valid());
        }
    }
}
