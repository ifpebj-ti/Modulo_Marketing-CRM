FROM mcr.microsoft.com/dotnet/sdk:6.0.414-alpine3.18-arm64v8 AS build-env

WORKDIR /app

COPY ModuloMarketing.Api/*.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish ModuloMarketing.Api/ModuloMarketing.Api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .


ENTRYPOINT ["dotnet", "ModuloMarketing.Api.dll"]
