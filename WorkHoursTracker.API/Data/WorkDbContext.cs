using Microsoft.EntityFrameworkCore;
using WorkHoursTracker.API.Models;

namespace WorkHoursTracker.API.Data;

public class WorkDbContext : DbContext
{
    public DbSet<WorkSession> WorkSessions { get; set; }

    public WorkDbContext(DbContextOptions<WorkDbContext> options)
        : base(options)
    {
    }
}
