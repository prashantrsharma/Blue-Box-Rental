# Blue-Box-Rental

Blue-Box-Rental is an fictional Movie Rental Company. The company has a website which is WIP , behind the scenes the website make a call to multiple microservices.

The project uses Microservices , API Gateway Pattern with Ocelot , Azure Functions v2.0 , .NET Core 2.1 Web API,.NET Core 2.1 MVC , Sakila DB for SQL 2016.

This is a novice attempt for building microservices.

The project structure goes like this :

1. BlueBoxRental.API.Gateway : .NET Core 2.1 Project (acts as a API Gateway) which Uses Ocelot , Ocelot is an Open Source .NET Core based API Gateway especially made for microservices architecture that need unified points of entry into their system.
URL:https://ocelot.readthedocs.io/en/latest/features/routing.html
GitHub URL :https://github.com/ThreeMammals/Ocelot

2. Sakila Database :Sakila Database using MS SQL 2016
The Sakila sample database was initially developed by Mike Hillyer, a former member of the MySQL AB documentation team, and is intended to provide a standard schema that can be used for examples in books, tutorials, articles, samples, and so forth. Sakila sample database also serves to highlight the latest features of MySQL such as Views, Stored Procedures, and Triggers.

URL:https://dev.mysql.com/doc/sakila/en/sakila-structure.html

3. BlueBoxRental.FilmServices : Azure Function v2.0 project with multiple microservices.
[Issue] : In the current state the database context is hardcoded in the Service, will have to find a way to Inject the database context 

4. BlueBoxRental.Entities: Class Library project with Database entities as POCOs using EFCorePower Tools
GitHub URL :https://github.com/ErikEJ/EFCorePowerTools
Visual Studio Market Place URL : https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools

5. BlueBoxRental.Web : .NET Core 2.1 MVC Project uses ASP.NET Core, ASP.NET Core is a cross-platform, high-performance, open-source framework for building modern, cloud-based, Internet-connected applications.


High Level Architectural Diagram



