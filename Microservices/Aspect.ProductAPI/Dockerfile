#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Aspect.ProductAPI.csproj", "."]
RUN dotnet restore "./Aspect.ProductAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Aspect.ProductAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aspect.ProductAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aspect.ProductAPI.dll"]