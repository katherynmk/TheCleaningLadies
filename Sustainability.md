To run our project, follow these steps:
- Download the GitHub Repository
- Install .NET 7 SDK through either Microsoft Visual Studio 2022 or later or [this link](https://dotnet.microsoft.com/en-us/learn/aspnet/hello-world-tutorial/install)
- Open the project in Microsoft Visual Studio and click the 'run' button, or navigate to the directory and run:
```
dotnet watch
```

To add a database, create a MongoDB database and get the connection string.
Replace the old connection string in UserService.cs. When the code runs, it will create everything needed in the database.
