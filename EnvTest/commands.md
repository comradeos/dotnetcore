dotnet new sln -n EnvTestSolution
dotnet new console -n EnvTestApp
dotnet sln EnvTestSolution.sln add EnvTestApp/EnvTestApp.csproj
dotnet build --configuration Release