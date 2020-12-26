ARG VERSION=5.0-alpine

FROM mcr.microsoft.com/dotnet/aspnet:$VERSION AS base
WORKDIR /dist
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:$VERSION AS build
WORKDIR /src
COPY ["Domain/*.csproj", "Domain/"]
COPY ["Application/*.csproj", "Application/"]
COPY ["Infrastructure/*.csproj", "Infrastructure/"]
COPY ["WebUI/*.csproj", "WebUI/"]
COPY ["./*.sln", "./"]

RUN dotnet restore WebUI/WebUI.csproj
COPY . .
RUN dotnet build ./WebUI/WebUI.csproj -c Release --no-restore

FROM build AS publish
RUN dotnet publish ./WebUI/WebUI.csproj -c Release --no-restore -o /dist

FROM base AS final
COPY --from=publish /dist .
ENTRYPOINT ["dotnet", "WebUI.dll"]