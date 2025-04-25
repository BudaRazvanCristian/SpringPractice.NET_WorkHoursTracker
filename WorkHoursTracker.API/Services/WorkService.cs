using WorkHoursTracker.API.Models;
using WorkHoursTracker.API.Data;
using WorkHoursTracker.API.Services;
using Microsoft.EntityFrameworkCore;

public class WorkService : IWorkService
{
    private readonly WorkDbContext _context;

    public WorkService(WorkDbContext context)
    {
        _context = context;
    }

    public string StartWork(string username)
    {
        _context.WorkSessions.Add(new WorkSession
        {
            Username = username,
            StartTime = DateTime.Now
        });
        _context.SaveChanges();
        return $"Session started for {username}";
    }

    public string StopWork(string username)
    {
        var session = _context.WorkSessions
            .Where(s => s.Username == username && s.EndTime == null)
            .OrderByDescending(s => s.StartTime)
            .FirstOrDefault();

        if (session == null)
            return $"No active session found for {username}";

        session.EndTime = DateTime.Now;
        _context.SaveChanges();
        return $"Session stopped for {username}. Duration: {session.Duration}";
    }

    public string GetTodaySummary(string username)
    {
        var today = DateTime.Today;
        var minutes = _context.WorkSessions
            .Where(s => s.Username == username && s.StartTime.Date == today && s.EndTime != null)
            .ToList()
            .Sum(s => s.Duration?.TotalMinutes ?? 0);

        return $"Today's total for {username}: {TimeSpan.FromMinutes(minutes):hh\\:mm}";
    }

    public string GetWeekSummary(string username)
    {
        var monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1);
        var minutes = _context.WorkSessions
            .Where(s => s.Username == username && s.StartTime >= monday && s.EndTime != null)
            .ToList()
            .Sum(s => s.Duration?.TotalMinutes ?? 0);

        return $"This week's total for {username}: {TimeSpan.FromMinutes(minutes):hh\\:mm}";
    }

    public List<WorkSession> GetFullLog(string username)
    {
        return _context.WorkSessions
            .Where(s => s.Username == username)
            .OrderByDescending(s => s.StartTime)
            .ToList();
    }
}
