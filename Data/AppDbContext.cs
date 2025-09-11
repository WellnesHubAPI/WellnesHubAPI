using Microsoft.EntityFrameworkCore;
using WellnesHubAPI.Data;
using WellnesHubAPI.models;

namespace WellnesHubAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Habit> Habits { get; set; }
    
}