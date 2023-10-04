FROM mcr.microsoft.com/dotnet/sdk:7.0-bookworm-slim-arm64v8 AS build-env

WORKDIR /app

COPY *.csproj ./ModuloMarketing.Api
RUN dotnet restore

COPY . ./ModuloMarketing.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .


ENTRYPOINT ["dotnet", "ModuloMarketing.Api.dll"]

