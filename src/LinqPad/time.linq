<Query Kind="Expression">
  <Connection>
    <ID>7909b5f7-75b8-4e81-b579-b85a8cdd1468</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// show the orders for sept, 2018
from sale in Orders
//where sale.OrderDate.Value.Year == 2018
//&&
//sale.OrderDate.Value.Month == 4
where sale.OrderDate >= new DateTime(2018,04,01)
&& sale.OrderDate < new DateTime(2018,5,1)
select new
{
  Company = sale.Customer.CompanyName,
  DateOrdered = sale.OrderDate,
  TimeToDelivery = sale.RequiredDate - sale.OrderDate
  
}