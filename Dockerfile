# Use the official ASP.NET Core runtime as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy the rest of the project files and build the application
COPY . .
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

# Expose the necessary port
EXPOSE 80

# Define the command to run the application
ENTRYPOINT ["dotnet", "Microsoft.NET.Sdk.Web.dll"]
