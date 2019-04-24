using System;
using System.Collections.Generic;

namespace Store.Domain.StoreContext.OrderItemCommands.Inputs
{
    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}