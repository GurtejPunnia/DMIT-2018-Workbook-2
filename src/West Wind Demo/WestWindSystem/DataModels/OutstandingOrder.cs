using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.DataModels
{
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
}
