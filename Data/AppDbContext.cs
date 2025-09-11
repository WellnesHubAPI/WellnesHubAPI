using Microsoft.EntityFrameworkCore;
using WellnesHubAPI.Data;

namespace WellnesHubAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    /*public DbSet<habits> Habits { get; set; }
    public DbSet<mood_entries> MoodEntries { get; set; }
    public DbSet<meals> Meals { get; set; }
    public DbSet<workouts> Workouts { get; set; }*/
    
}