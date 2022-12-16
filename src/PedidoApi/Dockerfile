#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PedidoApi/PedidoApi.csproj", "PedidoApi/"]
COPY ["BackOffice.Domain/BackOffice.Domain.csproj", "BackOffice.Domain/"]
RUN dotnet restore "PedidoApi/PedidoApi.csproj"
COPY . .
WORKDIR "/src/PedidoApi"
RUN dotnet build "PedidoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PedidoApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PedidoApi.dll"]