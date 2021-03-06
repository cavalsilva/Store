using System;
using System.Collections.Generic;
using FluentValidator;
using Store.Shared.Entities;

namespace Store.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if (product.QuantityOnHand < quantity)
                AddNotification("Quantity", "Product out of stock");

            product.DecreaseQuantity(quantity);

        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }

    }
}