FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "TechNation.Desafio.API/TechNation.Desafio.API.csproj"
COPY . .
WORKDIR "/src/TechNation.Desafio.API"
RUN dotnet build "TechNation.Desafio.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TechNation.Desafio.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechNation.Desafio.API.dll"]