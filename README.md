# VagasAqui.Backend
Backend VagasAqui

# Preparação

## Usando SQL Server no docker 

docker pull mcr.microsoft.com/mssql/server

docker run -v ~/docker --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1433:1433 -d mcr.microsoft.com/mssql/server

#### Connection String
Server=localhost,1433;Database=vagas_aqui;User ID=sa;Password=1q2w3e4r@#$


## Migrations

#### Instale as ferramentas de EF Core como uma ferramenta global e exclua o banco de dados
dotnet tool install --global dotnet-ef --version 5.0.3

#### Criando primeira migração
dotnet ef migrations add first-migration -p .\VA.Infrastructure.csproj -o .\Data\Migrations

-p para referencia o projeto e -o para informar a pasta de saída da migrações

#### Gerando script sql da migration
dotnet ef migrations script -p .\VA.Infrastructure.csproj -o .\Data\Migrations\Scipts\first-migration.sql -i

#### Aplicando migração ao banco 
dotnet ef database update -p .\VA.Infrastructure.Data.csproj -v
