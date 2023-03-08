### Basic EF

EF is a builtin || first party ORM for .NET

### Installation (No need to run again)

Global installation : 

`dotnet tool install --global dotnet-ef`

Add EFCore Design :

`dotnet add package Microsoft.EntityFrameworkCore.Design`

checking installaion :

`dotnet ef`

Install EF for MySQL :

`dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0`

### Work

Create Migration :

`dotnet ef migrations add AddNameToPlanTable`

Push Migration To Database

`dotnet ef database update`





