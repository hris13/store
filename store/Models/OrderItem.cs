using System;
using System.Collections.Generic;

namespace store.Models
{
    public partial class OrderItem
    {
        public int? OrderId { get; set; }
        public string? OrderItemName { get; set; }
        public int? Quantity { get; set; }
        public int OrderItemsId { get; set; }

        public virtual Order? Order { get; set; }
    }
}
