#need latest docker for this to work.
FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 433

FROM microsoft/dotnet:2.2-sdk AS build
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
