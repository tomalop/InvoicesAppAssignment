# InvoicesAppAssignment
Simple ASP .NET MVC to manage invoices in Azure CosmosDB with a simple API.

### Prerequisites
[ASP.NET Core](https://dotnet.microsoft.com/download/dotnet-core) **2.2** or newer - **.NET Core SDK**, **.NET Core Runtime** 
and **ASP.NET Core Runtime**

### Installing
A step by step series of examples that tell you how to get a development environment running.

1. Clone the repository

2. At the root directory, restore required packages by running:
```
dotnet restore
```
3. Add database key. Within root directory `DocumentDBRepository.cs` line 16 is missing correct string Key value, 
the correct key is provided in the email.
```
16.   private readonly string Key = "InsertKeyHere";
```
4. Next, build the solution by running:
```
dotnet build
```
5. To run the application, either use **.NET Run command** or press **F5 in Visual Studio** from project root directory.
```
dotnet run
```
### Live Demo
[MVC App](https://invoicesappmvc.azurewebsites.net/Invoice/Index)

[API](https://invoicesappmvc.azurewebsites.net/api)

## Built With
* [ASP.NET Core 2.2](https://github.com/aspnet/AspNetCore)
