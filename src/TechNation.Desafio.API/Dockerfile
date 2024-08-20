FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TechNation.Desafio.API/TechNation.Desafio.API.csproj", "src/TechNation.Desafio.API/"]
COPY ["src/TechNation.Desafio.Infra/TechNation.Desafio.Infra.csproj", "src/TechNation.Desafio.Infra/"]
COPY ["src/TechNation.Desafio.Application/TechNation.Desafio.Application.csproj", "src/TechNation.Desafio.Application/"]
COPY ["src/TechNation.Desafio.Domain/TechNation.Desafio.Domain.csproj", "src/TechNation.Desafio.Domain/"]
RUN dotnet restore "./src/TechNation.Desafio.API/TechNation.Desafio.API.csproj"
COPY . .
WORKDIR "/src/src/TechNation.Desafio.API"
RUN dotnet build "./TechNation.Desafio.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TechNation.Desafio.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechNation.Desafio.API.dll"]