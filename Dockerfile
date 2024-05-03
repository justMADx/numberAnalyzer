FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["numberAnalyzer/numberAnalyzer.csproj", "numberAnalyzer/"]
RUN dotnet restore "numberAnalyzer/numberAnalyzer.csproj"
COPY . .
WORKDIR "/src/numberAnalyzer"
RUN dotnet build "numberAnalyzer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "numberAnalyzer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "numberAnalyzer.dll"]
