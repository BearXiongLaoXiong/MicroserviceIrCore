#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base


RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /usr/lib/ssl/openssl.cnf
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /usr/lib/ssl/openssl.cnf

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
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