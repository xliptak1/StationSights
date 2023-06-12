# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy the rest of the project files and build the application
COPY . .
RUN dotnet publish -c Release -o out

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/out .

# Expose the desired port (change it to match your application)
EXPOSE 5029

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Microsoft.NET.Sdk.Web.dll"]
