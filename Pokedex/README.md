https://medium.com/@mohanedzekry/clean-architecture-in-asp-net-core-web-api-d44e33893e1d

dotnet new webapi
dotnet add package  Microsoft.EntityFrameworkCore.SqlServer
.    .   .   .   .  Microsoft.EntityFrameworkCore.InMemory 


dotnet ef migrations add InitialModel      
dotnet ef migrations remove
dotnet ef database update   