ARG VERSION=5.0-alpine

FROM mcr.microsoft.com/dotnet/aspnet:$VERSION AS base
WORKDIR /dist
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:$VERSION AS build
RUN apk add --update nodejs npm
WORKDIR /src
COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done

RUN dotnet restore WebUI/WebUI.csproj
COPY src .
RUN dotnet build ./WebUI/WebUI.csproj -c Release --no-restore

FROM build AS publish
RUN dotnet publish ./WebUI/WebUI.csproj -c Release --no-restore -o /dist

FROM base AS final
COPY --from=publish /dist .
ENTRYPOINT ["dotnet", "Restaurant.WebUI.dll"]