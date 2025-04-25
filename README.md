# WorkHoursTracker

A simple time tracking system (client-server) using Web API (.NET) and Console App.

---

## Project Structure

```
WorkHoursTracker/
├── WorkHoursTracker.API/       # Web API in .NET 8
├── WorkHoursTracker.Console/   # Console application (client)
├── deploy.sh                   # Deploy script for macOS/Linux
├── deploy.ps1                  # Deploy script for Windows
└── WorkHoursTracker.sln
```

---

## Features

Start/Stop work session  
 Daily and weekly summaries  
 Sessions stored in MySQL  
 Multi-user support (`username`)  
 Testable via Postman, Swagger or console app

---

## Technologies

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core 8 + Pomelo + MySQL
- Console Client App
- Swagger / Postman
- Cross-platform deployment scripts

---

## Requirements

- .NET SDK 8
- MySQL Server (default port 3306)
- `dotnet-ef` CLI (`dotnet tool install --global dotnet-ef`)

---

## How to Run

### Option 1: Using deployment script

#### macOS / Linux:

```bash
chmod +x deploy.sh
./deploy.sh
```

#### Windows:

```powershell
.\deploy.ps1
```

---

## API Endpoints

| Method | Endpoint          | Description               |
| ------ | ----------------- | ------------------------- |
| POST   | `/api/work/start` | Starts a new work session |
| POST   | `/api/work/stop`  | Stops the current session |
| GET    | `/api/work/today` | Today's total work time   |
| GET    | `/api/work/week`  | Weekly total work time    |
| GET    | `/api/work/logs`  | All work session logs     |

---

## Postman Examples

http://localhost:5173/api/work/start
http://localhost:5173/api/work/stop
http://localhost:5173/api/work/today
http://localhost:5173/api/work/week
http://localhost:5173/api/work/logs

---

## Database Info

The MySQL database is named `workhoursdb` and contains a table `WorkSessions`:

```sql
CREATE TABLE WorkSessions (
  Id CHAR(36) PRIMARY KEY,
  Username TEXT NOT NULL,
  StartTime DATETIME NOT NULL,
  EndTime DATETIME,
  ...
);
```
