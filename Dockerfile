FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["BoardGamesDirectory.Api/BoardGamesDirectory.Api.csproj", "BoardGamesDirectory.Api/"]
COPY ["BoardGamesDirectory.BusinessLogic/BoardGamesDirectory.BusinessLogic.csproj", "BoardGamesDirectory.BusinessLogic/"]
COPY ["BoardGamesDirectory.DataAccess/BoardGamesDirectory.DataAccess.csproj", "BoardGamesDirectory.DataAccess/"]

RUN dotnet restore "BoardGamesDirectory.Api/BoardGamesDirectory.Api.csproj"

COPY . .

WORKDIR "/src/BoardGamesDirectory.Api"
RUN dotnet build "BoardGamesDirectory.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BoardGamesDirectory.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BoardGamesDirectory.Api.dll"]