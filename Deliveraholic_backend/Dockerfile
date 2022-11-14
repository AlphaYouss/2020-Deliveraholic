# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY deliveraholic_backend/*.sln .
COPY deliveraholic_backend/*.csproj ./deliveraholic_backend/
RUN dotnet restore ./deliveraholic_backend

# copy everything else and build app
COPY . .
WORKDIR /source/deliveraholic_backend
RUN dotnet publish -c release -o /app 

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "deliveraholic_backend.dll"]