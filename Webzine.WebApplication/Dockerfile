#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Webzine.WebApplication/Webzine.WebApplication.csproj", "Webzine.WebApplication/"]
COPY ["Webzine.Services/Webzine.Services.csproj", "Webzine.Services/"]
COPY ["Webzine.Repository.Contracts/Webzine.Repository.Contracts.csproj", "Webzine.Repository.Contracts/"]
COPY ["Webzine.Entity/Webzine.Entity.csproj", "Webzine.Entity/"]
COPY ["Webzine.Services.Contracts/Webzine.Services.Contracts.csproj", "Webzine.Services.Contracts/"]
COPY ["Webzine.EntitiesContext/Webzine.EntitiesContext.csproj", "Webzine.EntitiesContext/"]
COPY ["Webzine.Repository/Webzine.Repository.csproj", "Webzine.Repository/"]
RUN dotnet restore "Webzine.WebApplication/Webzine.WebApplication.csproj"
COPY . .
WORKDIR "/src/Webzine.WebApplication"
RUN dotnet build "Webzine.WebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Webzine.WebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Webzine.WebApplication.dll"]