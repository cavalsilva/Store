using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using Store.Domain.StoreContext.Enums;
using Store.Shared.Entities;

namespace Store.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        
        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(Product product, decimal quantity)
        {
            // Validate Item
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Product {product.Title} has no {quantity} on stock");

            // Add to Order
            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }        

        // To Place An Order
        public void Place()
        {
            // Generate An Order Number
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();

            // Validate
            if (_items.Count == 0)
                AddNotification("Order", "This order has no items");

        }

        // Paid An Order
        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        // Shipping An Order
        public void Ship()
        {
            // Every 5 products is a delivery
            var deliveries = new List<Delivery>();
            var count = 1;
            
            // Break deliveries
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            // Delivery all Deliveries
            deliveries.ForEach(x => x.Ship());

            // Add Deliveries to an Order
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        // Cancelled An Order
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}