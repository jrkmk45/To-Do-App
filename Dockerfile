#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ToDoApp/ToDoApp.Web.csproj", "ToDoApp/"]
COPY ["ToDoApp.Application/ToDoApp.Application.csproj", "ToDoApp.Application/"]
COPY ["ToDoApp.DAL/ToDoApp.DAL.csproj", "ToDoApp.DAL/"]
COPY ["ToDoApp.Domain/ToDoApp.Domain.csproj", "ToDoApp.Domain/"]
RUN dotnet restore "./ToDoApp/./ToDoApp.Web.csproj"
COPY . .
WORKDIR "/src/ToDoApp"
RUN dotnet build "./ToDoApp.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ToDoApp.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoApp.Web.dll"]