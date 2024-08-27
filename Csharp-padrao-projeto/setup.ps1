mkdir DrawIoDesktop
mkdir DrawIoWeb
mkdir DrawIoLib

cd DrawIoLib
dotnet new classlib
cd ..

cd DrawIoDesktop
dotnet new winforms
dotnet add reference ..\DrawIoLib\DrawIoLib.csproj
cd ..

cd DrawIoWeb
dotnet new blazorserver
dotnet add reference ..\DrawIoLib\DrawIoLib.csproj
dotnet add package Blazor.Extensions.Canvas
cd ..