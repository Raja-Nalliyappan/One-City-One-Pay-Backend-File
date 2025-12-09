FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj for restore
COPY OneCityOnePay/*.csproj ./
RUN dotnet restore

# Copy rest of the files
COPY OneCityOnePay/. ./
RUN dotnet publish -c Release -o out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 8080
ENTRYPOINT ["dotnet", "OneCityOnePay.dll"]
