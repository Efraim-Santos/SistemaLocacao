#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SistemaLocacao.API/SistemaLocacao.API.csproj", "src/SistemaLocacao.API/"]
RUN dotnet restore "src/SistemaLocacao.API/SistemaLocacao.API.csproj"
COPY . .
WORKDIR "/src/src/SistemaLocacao.API"
RUN dotnet build "SistemaLocacao.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SistemaLocacao.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SistemaLocacao.API.dll"]