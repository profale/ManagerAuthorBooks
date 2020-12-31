#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ManagerAuthorBooks.API/ManagerAuthorBooks.API.csproj", "ManagerAuthorBooks.API/"]
COPY ["ManagerAuthorBooks.Infra/ManagerAuthorBooks.Infra.csproj", "ManagerAuthorBooks.Infra/"]
COPY ["ManagerAuthorBooks.Domain/ManagerAuthorBooks.Domain.csproj", "ManagerAuthorBooks.Domain/"]
RUN dotnet restore "ManagerAuthorBooks.API/ManagerAuthorBooks.API.csproj"
COPY . .
WORKDIR "/src/ManagerAuthorBooks.API"
RUN dotnet build "ManagerAuthorBooks.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ManagerAuthorBooks.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5000
ENTRYPOINT ["dotnet", "ManagerAuthorBooks.API.dll"]