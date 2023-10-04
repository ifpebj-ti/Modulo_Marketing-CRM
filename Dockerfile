# Use the appropriate base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0-bookworm-slim-arm64v8 AS build-env

WORKDIR /app

COPY *.sln ./

RUN mkdir aspnetapp
COPY ModuloMarketing.Api/*.csproj ./aspnetapp/

RUN dotnet restore

COPY ModuloMarketing.Api/. ./aspnetapp/

WORKDIR /app/aspnetapp

RUN dotnet publish -c release -o /app --no-restore

COPY --from=build-env /app ./

ENTRYPOINT ["dotnet", "aspnetapp.dll"]
