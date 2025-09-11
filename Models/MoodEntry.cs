namespace WellnesHubAPI.Models;

public class MoodEntry
{
    public int Id { get; set; }
    public string User { get; set; } = null!;
    public DateTime EntryDate { get; set; }
    public string? Mood { get; set; }       // e.g. happy, sad
    public int? Energy { get; set; }        // 1-10
    public double? SleepHours { get; set; }
    public int? StressLevel { get; set; }   // 1-10
}