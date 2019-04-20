using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Ricardo", "Silva");
            var document = new Document("01234567890");
            var email = new Email("ricardocavalcantesilva@gmail.com");
            var phone = "21999999999";
            var c = new Customer(name, document, email, phone);

            var mouse = new Product("Mouse", "Logitech MX Master", "mouse.png", 49.99M, 10);
            var keyboard = new Product("Keyboard", "Razer BlackWidow Ultimate", "keyboard.png", 69.99M, 20);
            var printer = new Product("Printer", "Brother Compact Monochrome Laser Printer", "printer.png", 99.99M, 15);
            var monitor = new Product("Monitor", "Dell D Series LED-Lit Monitor 31.5", "monitor.png", 140.99M, 12);

            var order = new Order(c);
            order.AddItem(mouse, 5);
            order.AddItem(keyboard, 5);
            order.AddItem(printer, 5);
            order.AddItem(monitor, 5);

            // Create Order
            order.Place();

            // Verify if order is valid
            var valid = order.IsValid;

            // Simulate Payment
            order.Pay();

            // Simulate Shipping
            order.Ship();

            // Simulate Cancel
            order.Cancel();
        }
    }
}
