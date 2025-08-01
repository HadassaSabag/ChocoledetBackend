# Base stage: Use a .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the solution file (.sln) and then the project files to the container
# Since Dockerfile is now inside ChocoledetBackend, we copy relative to that
COPY ["ChocoledetApp.sln", "./"] # <--- זה שם קובץ ה-Solution שלך
COPY ["App.Api/App.Api.csproj", "App.Api/"]
COPY ["App.BAL/App.BAL.csproj", "App.BAL/"]
COPY ["App.DAL/App.DAL.csproj", "App.DAL/"]
COPY ["App.DTO/App.DTO.csproj", "App.DTO/"]

# Restore dependencies for the entire solution
RUN dotnet restore "ChocoledetApp.sln"

# Copy the rest of the application code
# This copies the remaining files from the ChocoledetBackend directory
COPY . .

# Build the specific API project
WORKDIR "/src/App.Api" # <--- נווט/י לתיקיית הפרויקט API שלך
RUN dotnet build "App.Api.csproj" -c Release -o /app/build

# Publish stage: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS publish
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "App.Api.dll"]
