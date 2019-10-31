<Query Kind="Expression">
  <Connection>
    <ID>7909b5f7-75b8-4e81-b579-b85a8cdd1468</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Practice questions - do each one in a separate LinqPad query.

// A) Group employees by region and show the results in this format:
/*
from Person in Employees
group Person by Person.Address.Region into EmployeeGroups
select new
{
Region = EmployeeGroups.Key,
Employee = from staff in EmployeeGroups

select new 
{
FullName = staff.FirstName + " " + " " + staff.LastName

}

}

*/
/* ----------------------------------------------
 * | REGION        | EMPLOYEES                  |
 * ----------------------------------------------
 * | Eastern       | ------------------------   |
 * |               | | Nancy Devalio        |   |
 * |               | | Fred Flintstone      |   |
 * |               | | Bill Murray          |   |
 * |               | ------------------------   |
 * |---------------|----------------------------|
 * | ...           |                            |
 * 
 */

// B) List all the Customers by Company Name. Include the Customer's company name, contact name, and other contact information in the result.

/*
from customer in Customers
group customer by customer.CompanyName into CustomerGroups
select new
{
CompanyName = CustomerGroups.Key,
CustomerInfo = from person in CustomerGroups
select new
{
   Contact = person.ContactName,
   ContactTitle = person.ContactTitle,
   ContactEmail = person.ContactEmail
   
   
}
}

*/

from vendor in Customers
orderby vendor.CompanyName
select new 
{
CompanyName = vendor.CompanyName,
Contact = new 
{
Name = vendor.ContactName,
Title = vendor.ContactTitle,
Email = vendor.ContactEmail,
Phone = vendor.Phone,
Fax = vendor.Fax

}
}
// C) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.
/*from row in Employees 
orderby row.LastName  + row.FirstName ascending
select new
{

LastName = row.LastName,
FirstName = row.FirstName

}


*/

from person in Employees
orderby person.LastName, person.FirstName
select new
{
person.FirstName,
person.LastName,
OrderCount = person.SalesRepOrders.Count()
}
// D) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.


//same
	
// E) Group all customers by city. Output the city name, aalong with the company name, contact name and title, and the phone number.
/*
from person in Customers
group person by person.Address.City into PersonGroups
select new
{
City = PersonGroups.Key,
Customer = from customer in PersonGroups
select new
{
CustomerID = customer.CustomerID,
CompanyName = customer.CompanyName,
ContactName = customer.ContactName,
Title = customer.ContactTitle,
PhoneNumber = customer.Phone
} 

}
*/

from buyer in Customers
group buyer by buyer.Address.City into cityVendors
select new
{
City = cityVendors.Key,
Company = from company in cityVendors
select new
{
company.CompanyName,
company.ContactName,
company.ContactTitle,
company.Phone
}
}
// F) List all the Suppliers, by Country

from supplier in Suppliers
group supplier by supplier.Address.Country into SupplierGroups
select new
{
Country = SupplierGroups.Key,
Supplier = from person in SupplierGroups
select new
{

CompnayName = person.CompanyName,
ContactName = person.ContactName,
ContactTitle = person.ContactTitle
} 

}

from vendor in Suppliers
group vendor by vendor.Address.Country


//5 

//Select all orders a picker has done on a particular week (Sunday through Saturday). Group and sorted by picker. Sort the orders by picked date. Hint: you will need to use the join operator.

//Orders.Max(x=>.OrderDate).Value.DayOfWeek
DateTime start = new DateTime(2018,1,7).AddDays(-14);
DateTime end = start.AddDays(7);
var result = from sale in Orders
where sale.OrderDate >= start
&& sale.OrderDate < end
orderby sale.PickedDate
group sale by sale.PickerID into pickedOrders
select new
{
Picker = //pickOrders.Key,
Picker.Single(x => x.PickerID ==
pickedOrders.Key),
Orders = from pickedOrders
select new
{
Order = picked.OrderId,
Items = from item in picked.OrderLists
select new
{
Item = item.QtyOrdered,
Picked = item.QtyPicked
}
}
}