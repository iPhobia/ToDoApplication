FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ToDoApp.sln ./
COPY ToDoApp.Api/*.csproj ./ToDoApp.Api/
COPY ToDoApp.Core/*.csproj ./ToDoApp.Core/
COPY ToDoApp.Infrastructure/*.csproj ./ToDoApp.Infrastructure/

RUN dotnet restore 
COPY . .
WORKDIR /src/ToDoApp.Api/
RUN dotnet build  -c Release -o /app

WORKDIR /src/ToDoApp.Api/
RUN dotnet build  -c Release -o /app

WORKDIR /src/ToDoApp.Infrastructure/
RUN dotnet build  -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ToDoApp.Api.dll"]
