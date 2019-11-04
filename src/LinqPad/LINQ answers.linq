<Query Kind="Expression">
  <Connection>
    <ID>297aa279-262b-4a09-a2cc-3987943b64cc</ID>
    <Server>.</Server>
    <Database>GroceryList</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 1. Create a product list which indicates what products are purchased by our customers and how many times that product was purchased. Sort the list by most popular product by alphabetic description.

from item in Products
orderby item.OrderLists.Count() descending
select new
{
    Product = item.Description,
    TimesPurchased = item.OrderLists.Count()
}

// 2. We want a mailing list for a Valued Customers flyer that is being sent out. List the customer addresses for customers who have shopped at our stores. List by the store. 
// Include the store location as well as the customer's complete address. Do NOT include the customer name in the results. List the customer address only once for a particular store.

from place in Stores
select new
{
    Location = place.Location,
    Clients = from sale in place.Orders
              group sale by sale.Customer into customerSales
              select new
              {
                Address = customerSales.Key.Address,
                City = customerSales.Key.City,
                Province = customerSales.Key.Province
              }
}

// 3. Create a Daily Sales per Store request for a specified month. Sort stores by city by location. For Sales, show order date, number of orders, total sales without GST tax and total GST tax.

from place in Stores
orderby place.City, place.Location
select new
{
    place.City,
    place.Location,
    Sales = from sale in place.Orders
            where sale.OrderDate.Month == 12
                && sale.OrderDate.Year == 2017
            group sale by sale.OrderDate.Day into dailySales
            from daily in dailySales
            select new
            {
                Date = daily.OrderDate,
                NumberofOrders = daily.OrderLists.Count(),
                ProductSales = daily.SubTotal,
                GST = daily.GST
            }
}

// 4. Print out all product items on a requested order (use Order #33). Group by Category and order by Product Description. You do not need to format money as this would be done at the presentation level. 
//    Use the QtyPicked in your calculations. Hint: You will need to use type casting (decimal). Use of the ternary operator will help.

from x in OrderLists
group x by x.Product.Category.Description into l
orderby l.Key
select new{
Cat = l.Key,
OrderProducts = from item in l
where item.OrderID==33
select new{

Product= item.Product.Description,
Price= item.Price,
PickedQty= item.QtyPicked,
Discount= item.Discount,
Subtotal= item.Price,
Tax= (item.Price - item.Discount) * (decimal)0.05,
ExtendedPrice= item.Price + (decimal)0.05 * (item.Price - item.Discount)
}
}

// 5. 

from x in Pickers
orderby x.LastName + " " + x.FirstName
select new{

picker = x.LastName + "," + x.FirstName,

pickdates = from item in x.Store.Orders
where x.PickerID == item.PickerID && item.OrderDate >= new DateTime(2017,12,17) && item.OrderDate < new DateTime(2017,12,24)
orderby item.OrderDate ascending
select new{
ID=item.OrderID,
Date=item.OrderDate

}

}
 
// 6. List all the products a customer (use Customer #1) has purchased and the number of times the product was purchased. Sort the products by number of times purchased (highest to lowest) then description. 

from customer in Customers
where customer.CustomerID == 1
select new
{
    Customer = customer.LastName + ", " + customer.FirstName,
    OrdersCount = customer.Orders.Count(),
    Items = from order in OrderLists
    where order.Order.CustomerID == 1
    group order by order.Product.Description into products
    orderby products.Count() descending
    select new
    {
        Description = products.Key,
        TimesBought = products.Count()
    }
}

