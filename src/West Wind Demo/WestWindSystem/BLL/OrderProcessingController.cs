using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.DataModels;

namespace WestWindSystem.BLL
{
   public class OrderProcessingController
    {
        #region Queries
        public List<OutstandingOrder> LoadOrders(int supplierId)
        {
            throw new NotImplementedException();
        }
        public List<ShipperSelection> ListShippers()
        {
            using (var context = new WestWindContext())
            {
                var result = from shipper in context.Shippers
                             select new ShipperSelection
                             {
                                 ShipperId = shipper.ShipperID,
                                 Shipper = shipper.CompanyName
                             };
                return result.ToList();
            }
           
        }
        #endregion

        #region Commands

        public void ShipOrder(int orderId, ShippingDirections shipping, List<ProductShipment> products)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
