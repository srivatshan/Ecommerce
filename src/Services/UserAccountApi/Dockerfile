#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 443
ENV ASPNETCORE_URLS=https://*:44375

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Services/UserAccountApi/UserAccountApi.csproj", "src/Services/UserAccountApi/"]
RUN dotnet restore "src/Services/UserAccountApi/UserAccountApi.csproj"
COPY . .
WORKDIR "/src/src/Services/UserAccountApi"
RUN dotnet build "UserAccountApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserAccountApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserAccountApi.dll"]
