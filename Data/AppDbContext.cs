using Microsoft.EntityFrameworkCore;
using WellnesHubAPI.Data;
using WellnesHubAPI.models;
using WellnesHubAPI.Models;

namespace WellnesHubAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Habit> Habits { get; set; }
    public DbSet<MoodEntry> MoodEntries { get; set; }
}