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
// C) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.
/*from row in Employees 
orderby row.LastName  + row.FirstName ascending
select new
{

LastName = row.LastName,
FirstName = row.FirstName

}
*/
// D) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.

	
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
