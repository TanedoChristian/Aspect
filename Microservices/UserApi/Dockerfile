# Use the ASP.NET runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Set up the build environment
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the project file and restore NuGet packages
COPY ["UserApi.csproj", "."]
RUN dotnet restore "./UserApi.csproj"

# Copy the source code
COPY . .
WORKDIR "/src/."
RUN dotnet build "UserApi.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "UserApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Create the final image
FROM base AS final
WORKDIR /app

# Copy the published application
COPY --from=publish /app/publish .

# Copy the appsettings.json file into the image

# Set the entry point for the container
ENTRYPOINT ["dotnet", "UserApi.dll"]
