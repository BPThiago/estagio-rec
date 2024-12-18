# Usando a imagem oficial do .NET 8 SDK como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Diretório de trabalho no contêiner
WORKDIR /app

# Copiando o arquivo csproj e restaurando as dependências
COPY *.csproj ./
RUN dotnet restore

# Copiando o restante do código da aplicação
COPY . .

# Construindo a aplicação
RUN dotnet build -c Release

# Gerando o artefato da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS runtime

# Diretório de trabalho no contêiner para o ambiente de produção
WORKDIR /app

# Copiando a build da etapa anterior
COPY --from=build /app .

# Executando a aplicação
ENTRYPOINT ["dotnet", "EstagioREC.dll"]
