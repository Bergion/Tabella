#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0.102-ca-patch-buster-slim AS build
WORKDIR /src
COPY ["Microservices/Cabinet/Cabinet.API/Cabinet.API.csproj", "Microservices/Cabinet/Cabinet.API/"]
COPY ["Microservices/Cabinet/Cabinet.Storage/Cabinet.Storage.csproj", "Microservices/Cabinet/Cabinet.Storage/"]
RUN dotnet restore "Microservices/Cabinet/Cabinet.API/Cabinet.API.csproj"
COPY . .
WORKDIR "/src/Microservices/Cabinet/Cabinet.API"
RUN dotnet build "Cabinet.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cabinet.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cabinet.API.dll"]