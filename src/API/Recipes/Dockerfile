#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS http://+:51802;https://+:51803

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RecipesBook/RecipesBook.csproj", "RecipesBook/"]
RUN dotnet restore "RecipesBook/RecipesBook.csproj"
COPY . .
WORKDIR "/src/RecipesBook"
RUN dotnet build "RecipesBook.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecipesBook.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecipesBook.dll"]