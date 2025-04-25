using WorkHoursTracker.API.Models;

namespace WorkHoursTracker.API.Services;

public interface IWorkService
{
    string StartWork(string username);
    string StopWork(string username);
    string GetTodaySummary(string username);
    string GetWeekSummary(string username);
    List<WorkSession> GetFullLog(string username);
}
