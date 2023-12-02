### This command creates a new solution named "WebServices".
```
dotnet new sln -n WebServices
```
### This command creates a new Web API project named "GeneralApi"
```
dotnet new webapi -n GeneralApi
```
### This command adds the "GeneralApi" project to the "WebServices" solution.
```
dotnet sln WebServices.sln add GeneralApi/GeneralApi.csproj
```
### Installing Database Tools
```
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```
```
dotnet add package Microsoft.EntityFrameworkCore.Design
```
```
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
```
dotnet tool install --global dotnet-ef
```
### Create migration
```
dotnet ef migrations add MyFirstMigration
```
### Remove migration
```
dotnet ef database update
```
### Commit changes to database
```
dotnet ef migrations remove
```