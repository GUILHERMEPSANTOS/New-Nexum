FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./Services/Profile/NewNexum.Profile.Api/NewNexum.Profile.Api.csproj", "./Services/Profile/NewNexum.Profile.Api/"]
COPY ["./Building Blocks/Infrastructure/NewNexum.WebApi.Core/NewNexum.WebApi.Core.csproj", "./Building Blocks/Infrastructure/NewNexum.WebApi.Core/"]
COPY ["./Services/Profile/NewNexum.Profile.Application/NewNexum.Profile.Application.csproj", "./Services/Profile/NewNexum.Profile.Application/"]
COPY ["./Services/Profile/NewNexum.Profile.Persistence/NewNexum.Profile.Persistence.csproj", "./Services/Profile/NewNexum.Profile.Persistence/"]

WORKDIR /src
COPY . .
WORKDIR /src/Services/Profile/NewNexum.Profile.Api/
RUN dotnet build  NewNexum.Profile.Api.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish NewNexum.Profile.Api.csproj -c Release -o /app/publish

FROM runtime AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "NewNexum.Profile.Api.dll"]
