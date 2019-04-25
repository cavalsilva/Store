using System;
using Store.Domain.StoreContext.Enums;
using Store.Shared.Entities;

namespace Store.Domain.StoreContext.Entities
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estimateDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimateDeliveryDate = estimateDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimateDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            // If Estimated Date for past, dont delivery
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            // If status is not delivered, cancel the order
            if (Status != EDeliveryStatus.Delivered)
            {
                // Cancel An Order
                Status = EDeliveryStatus.Canceled;
            }

        }
    }
}