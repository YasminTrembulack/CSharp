https://github.com/trevisharp/HLSExample/blob/main/backend/Program.cs
https://learn.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-8.0
https://gist.github.com/lukebussey/4d27678c72580aeb660c19a6fb73e9ee


https://medium.com/@mohanedzekry/clean-architecture-in-asp-net-core-web-api-d44e33893e1d

dotnet new webapi
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add packag Microsoft.EntityFrameworkCore.InMemory 
dotnet add package Pomelo.EntityFrameworkCore.MySql

dotnet tool install --global dotnet-ef

dotnet ef migrations add InitialModel      
dotnet ef migrations remove
dotnet ef database update   

dotnet add package Microsoft.AspNetCore.Authentication
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

dotnet add package TagLibSharp

https://stackoverflow.com/questions/42741170/how-to-save-images-to-database-using-asp-net-core