#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RentalCars.Application/RentalCars.Application.csproj", "RentalCars.Application/"]
RUN dotnet restore "RentalCars.Application/RentalCars.Application.csproj"
COPY . .
WORKDIR "/src/RentalCars.Application"
RUN dotnet build "RentalCars.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RentalCars.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentalCars.Application.dll"]