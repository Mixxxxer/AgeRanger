**General**

- Visual Studio 2015 Enterprise
- Framework 4.5.2
- Remember to restore the NuGet packages before building.
- May have to change web.config to update the location of the SQLite DB
- If the DB does not exists, AgeRanger will create and seed it!

Added a TODO section to indicate that additional elements have been thought of but not specifically implemented. 

**Requirements**

1. [Done] Display a list of people with their First Name, Last Name, Age and Age Group
2. [Done] Allow users to search by First/Last name
3. [Done] Allow a new person to be added by providing First Name, Last Name and Age

4. [Done] Demonstrated unit testing
5. [Done] Demonstrated integration testing

**Wish List**

1. [Done] Single Page Application using AngulatJS with MVC (Little extra effort)
2. [Done] Consideration for DBA moving to SQL Server (Design considerations only)
3. [Done] WebAPI. Added basic WebAPI allowing and update. WebAPI uses a API Key and Basic Authentication.  

**Extras**

1. [Done] Edit and Delete functionality with minimal effort. Reusable for WebAPI 
2. [Done] Confirmed functionality in Chrome, IE and Edge. 
3. [Done] Basic functional test example creating a test person and asserting the values returned.

**Solution Structure**

* Projects

- AgeRanger - ASP.NET MVC Web Site with a SPA using AngularJS
- AgeRanger.Api - ASP.NET WebAPI which implement a PUT method for updaing using the shared Domain
- AgeRanger.Api.Client - Rough console Application that uses the API to update the person
- AgeRanger.Data - Repository Implementation that we can swap out when the DBA's goto SQL Server
- AgeRanger.Domain - Domain Driven Design Approach which will house our Factories, Service and much more
- AgeRanger.Entities - Entities that we can reuse

* Test Projects

- AgeRanger.Tests.Unit - Basic unit test that can be executed and has no dependencies 
- AgeRanger.Tests.Integration - Basic Integration tests that may have a dependency on disk, network etc.
- AgeRanger.Tests.Functional - Basic functional test demonstrating selenium web driver.

NOTE: I have not made an attempt to complete code coverage but rather attempted to demonstrate my understanding of the various types of testing.

**NuGet Packages**

Only listing packages that I specifically added.

1. Ninject - My prefered choice for dependency injection
2. SQLite - SQLLite and EF Providers
3. AngularJS - Needs no introduction
4. MoQ - Mocking framework for unit testing
5. Fluent Assertions - Makes tests more readable
6. Selenium Web Driver with the Chrome Driver

**Things TODO**

1. Security - Security consideration
	- Encrypt sensitive data for transfer (SLL are the first thing we can do)
	- Cross Site Anti Forgery
	- Forms / Windows Authentication
	- Role Based Security 
		- Administrators can Add/edit
		- Everyone can view

2. Duplicate check when adding new person
3. Error Handling in PersonController to improve feedback to UI
4. ModelState Validation and display on UI
5. Sleek popups for when saving, deleting or editing occurred
6. Confirmation dialogs where appropriate

**Testing Things TODO**

1. Test Coverage - JavaScript portions of the code can use Jasmin / Chutzpa or similar
2. Test Coverage - Remaining C# Portions of the Code
3. Test Coverage - Automated functional test using Selenium to drive the front end
4. Browser Based Testing - FireFox and Safari

**Cool Things TODO**

1. Use AppVeyor to setup automated builds on checking
2. Execute the unit and integration tests as part of the build

-----------------------------------------------

AgeRanger is a world leading application designed to identify person's age group!
The only problem with it is... It is not implemented - except a SQLite DB called AgeRanger.db.

To help AgeRanger to conquer the world please implement a web application that communicates with the DB mentioned above, 
and does the following:

 - Displays a list of people in the DB with their First and Last names, age and their age group. 
	The age group should be determened based on the AgeGroup DB table - a person belongs to the age group where person's 
	age >= 	than group's MinAge and < than group's MaxAge. Please note that MinAge and MaxAge can be null;

 - Allows user to search for a person by his/her first or last name and displays all relevant information for the person - 
	first and last names, age, age group.

 - Allows user to add a new person - every person has the first name, last name, and age;
 
In our fantasies AgeRanger is a single page application, and our DBA has already implied that he wants us to migrate 
	it to SQL Server some time in the future.

And unit tests! We love unit tests!

Last, but not the least - our sales manager suggests you'll get bonus points if the application will also allow 
user to edit existing person records and expose a WEB API.

Please fork the project.

You are free to use any technology and frameworks you need. However if you decide to go with third party package 
	manager or dev tool - don't forget to mention them in the README.md of your fork.

Good luck!