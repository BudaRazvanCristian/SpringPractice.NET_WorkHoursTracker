Write-Host "`n [1] Restoring packages..."
dotnet restore

Write-Host "`n [2] Building solution..."
dotnet build

Write-Host "`n [3] Applying EF Core migrations..."
dotnet ef database update --project WorkHoursTracker.API

Write-Host "`n [4] Starting Web API in new terminal..."
Start-Process powershell -ArgumentList "cd WorkHoursTracker.API; dotnet run"

Start-Sleep -Seconds 3

Write-Host "`n [5] Running Console App..."
cd WorkHoursTracker.Console
dotnet run
