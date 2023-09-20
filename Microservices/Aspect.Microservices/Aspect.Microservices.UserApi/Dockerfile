#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Aspect.Microservices.UserApi/Aspect.Microservices.UserApi.csproj", "Aspect.Microservices.UserApi/"]
RUN dotnet restore "Aspect.Microservices.UserApi/Aspect.Microservices.UserApi.csproj"
COPY . .
WORKDIR "/src/Aspect.Microservices.UserApi"
RUN dotnet build "Aspect.Microservices.UserApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aspect.Microservices.UserApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aspect.Microservices.UserApi.dll"]