using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.DataModels
{
    public class ShippingDirections
    {
        public int ShipperId { get; set; }
        public string TrackingCode { get; set; }
        public decimal? FreightCharge { get; set; }
    }
}
