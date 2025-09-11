namespace WellnesHubAPI.models;

public class Habit
{
    public int Id { get; set; }
    public string User { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Frequency { get; set; }  // e.g. daily, weekly
    public string? Status { get; set; }     // e.g. active, paused
}