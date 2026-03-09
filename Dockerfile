# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["AISearchUserAPI/AISearchUserAPI.csproj", "AISearchUserAPI/"]
RUN dotnet restore "AISearchUserAPI/AISearchUserAPI.csproj"

COPY . .
RUN dotnet build "AISearchUserAPI/AISearchUserAPI.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "AISearchUserAPI/AISearchUserAPI.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "AISearchUserAPI.dll"]
