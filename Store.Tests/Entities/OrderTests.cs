using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Enums;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;
        private Customer _customer;
        private Order _order;
        
        public OrderTests()
        {
            var _name = new Name("Ricardo", "Silva");
            var _document = new Document("13230609018");
            var _email = new Email("ricardocavalcantesilva@gmail.com");
            _customer = new Customer(_name, _document, _email, "5521999999999");
            _order = new Order(_customer);
            
            _mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Keyboard Gamer", "Keyboard gamer", "Keyboard.jpg", 100M, 10);
            _chair = new Product("Chair Gamer", "Chair Gamer", "chair.jpg", 100M, 10);
            _monitor = new Product("Monitor Gamer", "Monitor Gamer", "monitor.jpg", 100M, 10);
        }

        // Consigo criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        // Ao criar o pedido, o status deve ser created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // Ao adicionar um novo item, a quantidade deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddTwoValidItens()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        // Ao adicionar um novo item, deve subtrair a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedItem()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        // Ao confirmar pedido, deve gerar um número
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        // Ao pagar um pedido, o status deve ser PAGO
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        // Dados 10 produtos, devem haver duas entregas
        [TestMethod]
        public void ShouldTwoShippingsWhenPurchasedTenProducts()
        {
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        // Ao cancelar o pedido, o  status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled()
        {
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.Ship();

            _order.Cancel();

            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
        }        


    }
}
