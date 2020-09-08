FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8091
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["01UserInterface/MicroserviceCodeTable/MicroserviceCodeTable.csproj", "01UserInterface/MicroserviceCodeTable/"]
RUN dotnet restore "01UserInterface/MicroserviceCodeTable/MicroserviceCodeTable.csproj"
COPY . .
WORKDIR "/src/01UserInterface/MicroserviceCodeTable"
RUN dotnet build "MicroserviceCodeTable.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroserviceCodeTable.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroserviceCodeTable.dll"]
