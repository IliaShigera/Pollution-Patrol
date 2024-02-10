FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/API/PollutionPatrol.API/PollutionPatrol.API.csproj", "src/API/PollutionPatrol.API/"]
COPY ["src/BuildingBlocks/PollutionPatrol.BuildingBlocks.Infrastructure/PollutionPatrol.BuildingBlocks.Infrastructure.csproj", "src/BuildingBlocks/PollutionPatrol.BuildingBlocks.Infrastructure/"]
COPY ["src/BuildingBlocks/PollutionPatrol.BuildingBlocks.Application/PollutionPatrol.BuildingBlocks.Application.csproj", "src/BuildingBlocks/PollutionPatrol.BuildingBlocks.Application/"]
COPY ["src/BuildingBlocks/PollutionPatrol.BuildingBlocks.Domain/PollutionPatrol.BuildingBlocks.Domain.csproj", "src/BuildingBlocks/PollutionPatrol.BuildingBlocks.Domain/"]
COPY ["src/Modules/Admin/PollutionPatrol.Modules.Admin.Infrastructure/PollutionPatrol.Modules.Admin.Infrastructure.csproj", "src/Modules/Admin/PollutionPatrol.Modules.Admin.Infrastructure/"]
COPY ["src/Modules/Admin/PollutionPatrol.Modules.Admin.Application/PollutionPatrol.Modules.Admin.Application.csproj", "src/Modules/Admin/PollutionPatrol.Modules.Admin.Application/"]
COPY ["src/Modules/Admin/PollutionPatrol.Modules.Admin.Domain/PollutionPatrol.Modules.Admin.Domain.csproj", "src/Modules/Admin/PollutionPatrol.Modules.Admin.Domain/"]
COPY ["src/Modules/Reporting/PollutionPatrol.Modules.Reporting.Application/PollutionPatrol.Modules.Reporting.Application.csproj", "src/Modules/Reporting/PollutionPatrol.Modules.Reporting.Application/"]
COPY ["src/Modules/Reporting/PollutionPatrol.Modules.Reporting.Domain/PollutionPatrol.Modules.Reporting.Domain.csproj", "src/Modules/Reporting/PollutionPatrol.Modules.Reporting.Domain/"]
COPY ["src/Modules/UserAccess/PollutionPatrol.Modules.UserAccess.Infrastructure/PollutionPatrol.Modules.UserAccess.Infrastructure.csproj", "src/Modules/UserAccess/PollutionPatrol.Modules.UserAccess.Infrastructure/"]
COPY ["src/Modules/UserAccess/PollutionPatrol.Modules.UserAccess.Application/PollutionPatrol.Modules.UserAccess.Application.csproj", "src/Modules/UserAccess/PollutionPatrol.Modules.UserAccess.Application/"]
COPY ["src/Modules/UserAccess/PollutionPatrol.Modules.UserAccess.Domain/PollutionPatrol.Modules.UserAccess.Domain.csproj", "src/Modules/UserAccess/PollutionPatrol.Modules.UserAccess.Domain/"]
COPY ["src/Modules/Reporting/PollutionPatrol.Modules.Reporting.Infrastructure/PollutionPatrol.Modules.Reporting.Infrastructure.csproj", "src/Modules/Reporting/PollutionPatrol.Modules.Reporting.Infrastructure/"]
RUN dotnet restore "src/API/PollutionPatrol.API/PollutionPatrol.API.csproj"
COPY . .
WORKDIR "/src/src/API/PollutionPatrol.API"
RUN dotnet build "PollutionPatrol.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PollutionPatrol.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PollutionPatrol.API.dll"]
