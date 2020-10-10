#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["FridaUi/FridaUi.csproj", "FridaUi/"]
RUN dotnet restore "FridaUi/FridaUi.csproj"
COPY . .
WORKDIR "/src/FridaUi"
RUN dotnet build "FridaUi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FridaUi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FridaUi.dll"]