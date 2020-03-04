FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY WebApiHeroku.sln ./
COPY WebApiHeroku.Core/*.csproj ./WebApiHeroku.Core/
COPY WebApiHeroku.Api/*.csproj ./WebApiHeroku.Api/

RUN dotnet restore
COPY . .

WORKDIR /src/WebApiHeroku.Core
RUN dotnet build -c Release -o /app

WORKDIR /src/WebApiHeroku.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app . 

CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebApiHeroku.Api.dll