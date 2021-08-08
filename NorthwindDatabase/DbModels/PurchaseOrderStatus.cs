using System;
using System.Collections.Generic;

#nullable disable

namespace NorthwindDatabase.DbModels
{
    public partial class PurchaseOrderStatus
    {
        public PurchaseOrderStatus()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
