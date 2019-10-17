# Order Processing

> Orders are shipped directly from our suppliers to our customers. As such, suppliers log onto our system to see what orders there are for the products that they provide.

## User Interface

Suppliers will be interacting with a page that shows the following information.

![Mockup](./Shipping-Orders.svg)

The information shown here will be displayed in a **ListView**, using the *SelectedItemTemplate* as the part that shows the details for a given order.

## POCOs/DTO

The POCOs/DTOs are simply classes that willl hold our data when we are performing Queries or issuing commands to the BLL. 



### Queries

csharp

public class OrderProductInformation
{
    Public int ProductID {get; set;}
    Public string ProductName {get; set;}
    Public short Qty {get; set;}
    Public string QtyPerUnit {get; set;}
    Public Short Outstanding {get; set;}
   
}

### Commands



## BLL Processing
