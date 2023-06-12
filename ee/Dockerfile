FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app1
COPY ./bin/Release/net7.0/publish .
ENTRYPOINT ["dotnet", "Microsoft.NET.Sdk.Web.dll"]
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
