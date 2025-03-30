$query="CREATE LOGIN [IIS APPPOOL\PTTrips] FROM WINDOWS;"
Invoke-Sqlcmd -ServerInstance ".\sql2022" -Query $query -TrustServerCertificate