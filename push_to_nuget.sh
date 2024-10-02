dotnet build --configuration Release
dotnet pack --configuration Release
nuget push ./EntityLib/bin/Release/Maxwell.EntityLib.1.0.1.nupkg -Source https://api.nuget.org/v3/index.json