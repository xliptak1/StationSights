# Use the official ASP.NET Core runtime as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj .

# Define the command to run the application
ENTRYPOINT ["dotnet", "Microsoft.NET.Sdk.Web.dll"]
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
