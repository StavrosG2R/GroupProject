# GroupProject
This is the group project developed for Peoplecert's Coding Bootcamp group assignemnt. 
The app intends to replicate a site where the user can browse premade PC builds or create their own and post it on the website.

Technologies used:
ASP.NET Framework 5
Entity Framework (Code first migrations)
SQL Server

Back end Architecture:
We tried to write the code as clean as possible, implmenting clean architecture. We seperated the project in two parts, Data Access(class library) and Group Project(Main Project).
In Data Access we have included all the entities, repositories and interfaces, while in Group Project we set up the main MVC program with it's dependencies.
We implemented Dependency injection. All database relations and have been declared using Fluent API through configuration classes.

Front end Architecture:
Ravor views are being used for the time being. We have implemented a dashboard for admin purposes and a custom bootstrap template for the landing page and the pages a user can access.

Users can be divided into simple Users when logged in or Admins
Admins can use CRUD operations for all the PC parts (GPUS, CPUS, Motherboards etc) and create Suggested Builds for future users to browse
Users can create User builds and follow other users(work in progress)

