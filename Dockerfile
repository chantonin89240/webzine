#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["Webzine.WebApplication/Webzine.WebApplication.csproj", "Webzine.WebApplication/"]
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