using Microsoft.EntityFrameworkCore;
using WellnesHubAPI.Models;

namespace WellnesHubAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Habit> Habits { get; set; }
    
    public DbSet<Meal> Meals { get; set; }
    
    public DbSet<MoodEntry> MoodEntries { get; set; }
}