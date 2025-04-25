namespace WorkHoursTracker.API.Models;

public class WorkSession
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = "default"; 
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    public TimeSpan? Duration =>
        EndTime.HasValue ? EndTime - StartTime : null;
}
