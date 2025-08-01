# Base stage: Use a .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything from the current directory (ChocoledetBackend) into /src in the container
COPY . .

# Restore dependencies for the solution
RUN dotnet restore "ChocoledetApp.sln"

# Build the specific API project
WORKDIR "/src/App.Api"
RUN dotnet build "App.Api.csproj" -c Release -o /app/build

# Publish stage: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS publish
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "App.Api.dll"]
