FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["HumanResources.API/HumanResources.API.csproj", "HumanResources.API/"]
COPY ["HumanResources.Core/HumanResources.Core.csproj", "HumanResources.Core/"]
COPY ["HumanResources.Infrastructure/HumanResources.Infrastructure.csproj", "HumanResources.Infrastructure/"]
COPY ["HumanResources.Usecase/HumanResources.Usecase.csproj", "HumanResources.Usecase/"]
RUN dotnet restore "HumanResources.API/HumanResources.API.csproj"
COPY . .

WORKDIR "/src/HumanResources.API"
RUN dotnet build "HumanResources.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "HumanResources.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "HumanResources.API.dll" ]