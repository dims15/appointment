FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR /source
RUN dotnet publish -c release -o /app --no-restore

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./

# Set the entry point to run migrations and then start the application
ENTRYPOINT ["dotnet", "appointments.dll"]