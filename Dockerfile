# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia a solução e restaura a
s dependências
COPY ./*.sln ./
COPY ./src/PsyApp.UI/*.csproj ./src/PsyApp.UI/
RUN dotnet restore ./src/PsyApp.UI/PsyApp.UI.csproj

# Copia o restante do código e faz o build
COPY ./src/PsyApp.UI/. ./src/PsyApp.UI/
WORKDIR /app/src/PsyApp.UI
RUN dotnet publish -c Release -o /publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "PsyApp.UI.dll"]
