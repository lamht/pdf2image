#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["pdf2image/pdf2image.csproj", "pdf2image/"]
RUN dotnet restore "pdf2image/pdf2image.csproj"
COPY . .
WORKDIR "/src/pdf2image"
RUN dotnet build "pdf2image.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "pdf2image.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN apt-get update && apt-get install -y poppler-utils
ENTRYPOINT ["dotnet", "pdf2image.dll"]