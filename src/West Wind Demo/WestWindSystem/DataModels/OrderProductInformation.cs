using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.DataModels
{
    public class OrderProductInformation
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public short Qty { get; set; }
        public string QtyPerUnit { get; set; }
        public short Outstanding { get; set; }

    }
  }
