# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["InnoClinic.Services.API/InnoClinic.Services.API.csproj", "InnoClinic.Services.API/"]
COPY ["InnoClinic.Services.Application/InnoClinic.Services.Application.csproj", "InnoClinic.Services.Application/"]
COPY ["InnoClinic.Services.Core/InnoClinic.Services.Core.csproj", "InnoClinic.Services.Core/"]
COPY ["InnoClinic.Services.DataAccess/InnoClinic.Services.DataAccess.csproj", "InnoClinic.Services.DataAccess/"]
COPY ["InnoClinic.Services.Infrastructure/InnoClinic.Services.Infrastructure.csproj", "InnoClinic.Services.Infrastructure/"]

RUN dotnet restore "InnoClinic.Services.API/InnoClinic.Services.API.csproj"

COPY . .

WORKDIR "/src/InnoClinic.Services.API"
RUN dotnet build "InnoClinic.Services.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "InnoClinic.Services.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InnoClinic.Services.API.dll"]