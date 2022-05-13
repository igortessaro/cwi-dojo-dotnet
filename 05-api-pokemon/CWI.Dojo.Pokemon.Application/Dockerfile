#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CWI.Dojo.Pokemon.Application/CWI.Dojo.Pokemon.Application.csproj", "CWI.Dojo.Pokemon.Application/"]
RUN dotnet restore "CWI.Dojo.Pokemon.Application/CWI.Dojo.Pokemon.Application.csproj"
COPY . .
WORKDIR "/src/CWI.Dojo.Pokemon.Application"
RUN dotnet build "CWI.Dojo.Pokemon.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CWI.Dojo.Pokemon.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CWI.Dojo.Pokemon.Application.dll"]