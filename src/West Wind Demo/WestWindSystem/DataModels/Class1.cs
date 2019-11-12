using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.DataModels
{
    class Class1
    {
        public class ShipperSelection
        {
            public int ShipperId { get; set; }
            public string Shipper { get; set; }
        }
        public class OutstandingOrder
        {
            public int OrderId { get; set; }
            public string ShipToName { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime RequiredBy { get; set; }
            public TimeSpan DaysRemaining { get; } // Calculated
            public IEnumerable<OrderProductInformation> OutstandingItems { get; set; }
            public string FullShippingAddress { get; set; }
            public string Comments { get; set; }
        }
        public class OrderProductInformation
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public short Qty { get; set; }
            public string QtyPerUnit { get; set; }
            public short Outstanding { get; set; }
            // NOTE: Outstanding <= OrderDetails.Quantity - Sum(ManifestItems.ShipQuantity) for that product/order

            public class ShippingDirections
            {
                public int ShipperId { get; set; }
                public string TrackingCode { get; set; }
                public decimal? FreightCharge { get; set; }
            }
            public class ProductShipment
            {
                public int ProductId { get; set; }
                public int ShipQuantity { get; set; }
            }
        }
    }
}
