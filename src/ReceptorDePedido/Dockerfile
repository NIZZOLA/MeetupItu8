#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ReceptorDePedido/ReceptorDePedido.csproj", "ReceptorDePedido/"]
COPY ["BackOffice.Infra.Sql/BackOffice.Infra.Sql.csproj", "BackOffice.Infra.Sql/"]
COPY ["BackOffice.Domain/BackOffice.Domain.csproj", "BackOffice.Domain/"]
RUN dotnet restore "ReceptorDePedido/ReceptorDePedido.csproj"
COPY . .
WORKDIR "/src/ReceptorDePedido"
RUN dotnet build "ReceptorDePedido.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReceptorDePedido.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReceptorDePedido.dll"]