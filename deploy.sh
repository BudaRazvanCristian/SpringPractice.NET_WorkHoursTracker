#!/bin/bash
echo " [1] Restoring packages..."
dotnet restore

echo " [2] Building solution..."
dotnet build

echo " [3] Applying EF Core migrations..."
dotnet ef database update --project WorkHoursTracker.API

echo " [4] Starting Web API in a new terminal..."
osascript <<END
tell application "Terminal"
    do script "cd \"$(pwd)/WorkHoursTracker.API\" && dotnet run"
end tell
END

sleep 3

echo " [5] Running Console App..."
cd WorkHoursTracker.Console
dotnet run
