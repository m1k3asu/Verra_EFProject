# Verra_EFProject
DotNet Test Project

This project was built with the target frameworke of .Net 7.0
The following Nuget Packages where added
- Microsoft.EntityFrameworkCore 7.0.13
- Microsoft.EntityFrameworkCore.Design 7.0.13
- Microsoft.EntityFrameworkCore.Sqlite 7.0.13
- Microsoft.EntityFrameworkCore.Tools  7.0.13

You may need to restore the Nuget packages to rebuild.

You will also find a Project.db file which is a SqLite db.

This project details
 1.	Created a new database called Project.db
 2.	Create two tables using a code-first migration in EF
	a.	Project table
	b.	Address table containing Country name
 3.	Manually added a few country records to seed the tables via migration from the url below
 4.	Create an action method to returns the list of Projects along with Country 		
        (GetRegisterList)
 5.	Create an action method to returns the list of Projects 
		(GetProjects)
 6.	Create an action method to returns the list of Countries
        (GetAddresses)


 Used the following ulr for a master list of countries:	
 https://countriesnow.space/api/v0.1/countries/states
