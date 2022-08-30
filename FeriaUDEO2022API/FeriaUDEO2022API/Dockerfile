#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FeriaUDEO2022API/FeriaUDEO2022API.csproj", "FeriaUDEO2022API/"]
RUN dotnet restore "FeriaUDEO2022API/FeriaUDEO2022API.csproj"
COPY . .
WORKDIR "/src/FeriaUDEO2022API"
RUN dotnet build "FeriaUDEO2022API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FeriaUDEO2022API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FeriaUDEO2022API.dll"]