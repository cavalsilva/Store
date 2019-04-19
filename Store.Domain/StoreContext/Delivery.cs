using System;

namespace Store.Domain.StoreContext
{
    public class Delivery
    {
        public DateTime CreateDate { get; set; }        
        public DateTime EstimateDeliveryDate { get; set; }        
        public string Status { get; set; }
    }
}