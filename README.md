# Torneio_Cor_Api_Mvc_Ef


BANCO SQLSERVER

PowerShell

pull imagem
docker pull microsoft/mssql-server-linux:2017-latest

configurar container
docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=leafar17' -p 1433:1433 --name sqlserver -d microsoft/mssql-server-linux:2017-latest

executar
docker start sqlserver

_____________________________________________________________________________________________________________________________

GERAR BANCO

Visual Studio - PowerShell

Add-Migration InitialCreate

Update-Database