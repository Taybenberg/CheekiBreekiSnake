#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CheekiBreekiSnake/CheekiBreekiSnake.csproj", "CheekiBreekiSnake/"]
COPY ["SnakeLib/SnakeLib.csproj", "SnakeLib/"]
COPY ["StalkerBot/StalkerBot.csproj", "StalkerBot/"]
RUN dotnet restore "CheekiBreekiSnake/CheekiBreekiSnake.csproj"
COPY . .
WORKDIR "/src/CheekiBreekiSnake"
RUN dotnet build "CheekiBreekiSnake.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CheekiBreekiSnake.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CheekiBreekiSnake.dll"]