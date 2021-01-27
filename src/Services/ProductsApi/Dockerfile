#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 443
ENV ASPNETCORE_URLS=https://localhost:44378

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Services/ProductsApi/ProductsApi.csproj", "src/Services/ProductsApi/"]
RUN dotnet restore "src/Services/ProductsApi/ProductsApi.csproj"
COPY . .
WORKDIR "/src/src/Services/ProductsApi"
RUN dotnet build "ProductsApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductsApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductsApi.dll"]
