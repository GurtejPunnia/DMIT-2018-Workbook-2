<Query Kind="Expression">
  <Connection>
    <ID>e4cac3fc-d638-45de-8757-3f8239b31f9c</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Practice questions - do each one in a separate LinqPad query.
/*

A) List all the customer company names for those with more than 5 orders.
 
   

B) Get a list of all the region names
C) Get a list of all the territory names
D) List all the regions and the number of territories in each region
E) List all the region and territory names in a "flat" list
F) List all the region and territory names as an "object graph"
   - use a nested query
G) List all the product names that contain the word "chef" in the name.
H) List all the discontinued products, specifying the product name and unit price.
I) List the company names of all Suppliers in North America (Canada, USA, Mexico)

*/


//A) List all the customer company names for those with more than 5 orders.


/*from CompanyName in Customers
where CompanyName.Orders.Count >=5
select CompanyName 

*/

//B) Get a list of all the region names

/*
from RegionDescription in Regions
select RegionDescription

*/

//C) Get a list of all the territory names

/*
from data in Territories
select new
{
    Territory = data.TerritoryDescription
    
}

*/

//D) List all the regions and the number of territories in each region


from place in Regions 
select new
{
Region = place.RegionDescription,
TerritoryCount = place.Territories.Count()
}

//E) List all the region and territory names in a "flat" list

/*from data in Territories
select new
{
   Territory = data.TerritoryDescription,
   Region = data.Region.RegionDescription
}
*/

//F) List all the region and territory names as an "object graph"
   //- use a nested query

/*from data in Territories
select new
{
Territory = data.TerritoryDescription,
Region = from item in Regions
select item.RegionDescription
}
*/

//G) List all the product names that contain the word "chef" in the name.
/*
from data in Products
where data.ProductName.Contains("chef")
select data.ProductName

*/

// H) List all the discontinued products, specifying the product name and unit price.
/*
from data in Products 
where data.Discontinued == true
select new

{
Product = data.ProductName,
Price = data.UnitPrice,
Discontinued = data.Discontinued
}

*/


//I) List the company names of all Suppliers in North America (Canada, USA, Mexico)


 from vendor in Suppliers
 where vendor.Address.Country == "Canada"
 ||  vendor.Address.Country == "USA"
 ||  vendor.Address.Country == "Mexico"
 select vendor.CompanyName