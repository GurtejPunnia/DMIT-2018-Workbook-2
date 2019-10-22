<Query Kind="Expression">
  <Connection>
    <ID>6946cc93-1af7-4287-8535-04fce39b0424</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Server>.</Server>
    <Database>GroceryList</Database>
  </Connection>
</Query>

//1.Create a product list which indicates what products are purchased by our customers and how many times
 // that product was purchased. Sort the list by most popular product by alphabetic description.
 
 
 from product in Products
 orderby product.OrderLists.Sum(lineItem => lineItem.QtyOrdered ) descending
 select new
 {
 
 Product = product.Description,
 TimesPurchased =  product.OrderLists.Sum(lineItem => lineItem.QtyOrdered),
 
 }
 



// .2 We want a mailing list for a Valued Customers flyer that is being sent out.
//List the customer addresses for customers who have shopped at our stores. List by the store.
//Include the store location as well as the customer's complete address. Do NOT include the customer name in the results. List the customer

from customer in Orders
group customer by customer.Store.Location into StoreLocation
select new
{
    Location = StoreLocation.Key,
	Client = from x in StoreLocation
	           select new
               {
			       Adress = x.Customer.Address,
				   City = x.Customer.City,
				   Province = x.Customer.Province
               }
}

//3.Create a Daily Sales per Store request for a specified month. Sort stores by city by location.
//For Sales, show order date, number of orders, total sales without GST tax and total GST tax.


from x in Stores
select new
{
x.City,
x.Location,
Sales = from y in Orders
where y.OrderDate >= new DateTime (2017,12,01) && y.OrderDate < new DateTime(2018,01,01)
select new
{

date = y.OrderDate,
numberoforders = y.OrderLists.Count(),
productsales = y.SubTotal,
gst = y.GST
} 

}

// 4.Print out all product items on a requested order (use Order #33). Group by Category and order by Product Description. 
//You do not need to format money as this would be done at the presentation level. Use the QtyPicked in your calculations.
//Hint: You will need to use type casting (decimal). Use of the ternary operator will help.


from customer in Products

group customer by customer.Category.Description into StoreLocation


select new
{
    Location = StoreLocation.Key,
	OrderProducts = from x in StoreLocation
	
	           select new
               {
			       Product = x.Description,
				   Price = x.Price,
				   PickedQty = x.OrderLists.Count(),
				   Discount = x.Discount,
				   Tax = x.Discount
               }
}



// 6.List all the products a customer (use Customer #1) has purchased and the number of times the product was purchased.
//Sort the products by number of times purchased (highest to lowest) then



from x in Customers
where x.CustomerID == 1
select new {
Customer = x.LastName + " " + " " + x.FirstName,
OrderCount = x.Orders.Count(),
Items = from y in OrderLists
where y.Order.CustomerID == 1
group y by y.Product.Description into products
orderby products.Count() descending 
select new
{
description = products.Key,
timesbought = products.Count()

}

}
