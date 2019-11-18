#need latest docker for this to work.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 433

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["SmashApi.csproj", "./"]
RUN dotnet restore "./SmashApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./SmashApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "./SmashApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "./SmashApi.dll"]
