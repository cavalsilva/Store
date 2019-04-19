using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;

namespace Store.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer(
                "Ricardo",
                "Silva",
                "123456789",
                "ricardocavalcantesilva@gmail.com",
                "999999999",
                "Rua dos Devs N° 42");

            var order = new Order(c);
        }
    }
}
