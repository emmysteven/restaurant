ARG VERSION=5.0-alpine

FROM mcr.microsoft.com/dotnet/aspnet:$VERSION AS base
WORKDIR /dist
EXPOSE 80
RUN apk add --update nodejs npm

FROM mcr.microsoft.com/dotnet/sdk:$VERSION AS build
RUN apk add --update nodejs npm
WORKDIR /src
COPY Domain/Domain.csproj /Domain/
COPY Application/Application.csproj /Application/
COPY Infrastructure/Infrastructure.csproj /Infrastructure/
COPY WebUI/WebUI.csproj /WebUI/
COPY ./*.sln ./

RUN dotnet restore /WebUI/WebUI.csproj
COPY . .
RUN dotnet publish ./WebUI/WebUI.csproj -c Release -o /dist

FROM base AS final
COPY --from=build /dist .
ENTRYPOINT ["dotnet", "WebUI.dll"]