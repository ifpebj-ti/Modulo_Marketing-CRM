FROM mcr.microsoft.com/dotnet/sdk:7.0-bookworm-slim-arm64v8 AS build-env

RUN apt-get update && \
    apt-get upgrade -y && \
    apt-get install -y git dotnet-sdk-6.0 aspnetcore-runtime-6.0 zlib1g && \
    rm -rf /var/lib/apt/lists/*

RUN git clone https://github.com/ifpebj-ti/Modulo_Marketing-CRM.git

WORKDIR /Modulo_Marketing-CRM/ModuloMarketing.Api

RUN dotnet publish -c Release

WORKDIR ./bin/Release/net6.0/publish

ENTRYPOINT ["dotnet", "ModuloMarketing.Api.dll"]

