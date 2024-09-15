FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./Services/Users/NewNexum.Users.Api/*.csproj", "./Services/Users/NewNexum.Users.Api/"]
COPY ["./Services/Users/NewNexum.Users.Application/*.csproj", "./Services/Users/NewNexum.Users.Application/"]
COPY ["./Services/Users/NewNexum.Users.Persistence/*.csproj", "./Services/Users/NewNexum.Users.Persistence/"]
COPY ["./Building Blocks/Infrastructure/NewNexum.Infra.Database/*.csproj", "./Building Blocks/Infrastructure/NewNexum.Infra.Database/"]
COPY ["./Building Blocks/Infrastructure/NewNexum.WebApi.Core/*.csproj", "./Building Blocks/Infrastructure/NewNexum.WebApi.Core/"]

RUN dotnet restore "./Services/Users/NewNexum.Users.Api/NewNexum.Users.Api.csproj"
COPY . .
WORKDIR "./Services/Users/NewNexum.Users.Api"
RUN dotnet build "./NewNexum.Users.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NewNexum.Users.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewNexum.Users.Api.dll"]