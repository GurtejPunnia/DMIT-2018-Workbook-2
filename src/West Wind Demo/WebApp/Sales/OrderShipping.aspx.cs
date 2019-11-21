using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Admin.Security;
using WestWindSystem.BLL;
using WestWindSystem.DataModels;

namespace WebApp.Sales
{
    public partial class OrderShipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only allow suppliers to use/access this page
            if (!Request.IsAuthenticated || !User.IsInRole(Settings.SupplierRole))
                Response.Redirect("~", true);
            
            if(!IsPostBack) // GET - first visit to the page
            {
                // Load up the info on the supplier
                // TODO: Replace hard-coded supplier ID with the user's supplier ID
                // - Show Company name and contact
                SupplierInfo.Text = "Temp supplier: ID 2";
            }
        }

        protected void CurrentOrders_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "Ship")
            {
                int orderId = 0;
                ShippingDirections shippingInfo = new ShippingDirections();
                Label idLabel = e.Item.FindControl("OrderIdLabel") as Label;
                if(idLabel != null)
                {
                    orderId = int.Parse(idLabel.Text);
                }
                DropDownList shipVia = e.Item.FindControl("ShipperDropDown") as DropDownList;
                if (shipVia != null)
                {
                    shippingInfo.ShipperId = int.Parse(shipVia.SelectedValue);
                }

                TextBox tracking = e.Item.FindControl("TrackingCode") as TextBox;
                if (tracking != null)

                    shippingInfo.TrackingCode = tracking.Text;

                TextBox freight = e.Item.FindControl("FreightCharge") as TextBox;
                decimal charge;
                if (freight != null && decimal.TryParse(freight.Text, out charge))        
                    shippingInfo.FreightCharge = charge;
                // Extract the items being shipped, as per the gridview
                List<ProductShipment> itemsShipped = new List<ProductShipment>();
                GridView gv = e.Item.FindControl("ProductsGridView") as GridView;
                if( gv != null)
                {
                    foreach( GridViewRow row in gv.Rows)
                    {
                        HiddenField proHidden = row.FindControl("ProdId") as HiddenField;
                        TextBox shipqty = row.FindControl("ShipQuantity") as TextBox;
                        if (proHidden != null && shipqty != null)
                        {
                            int qty;
                            if(int.TryParse(shipqty.Text, out qty))
                            {
                                var item = new ProductShipment
                                {
                                    ProductId = int.Parse(proHidden.Value),
                                    ShipQuantity = qty
                                };
                                itemsShipped.Add(item);
                            }
                        }
                    }
                }
                MessageUserControl.TryRun(() =>
                {
                    var controller = new OrderProcessingController();
                    controller.ShipOrder(orderId, shippingInfo, itemsShipped);
                },
                "Success", "The order has been shipped") ;
                

            }
        }
    }
}