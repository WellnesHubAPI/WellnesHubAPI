using System.ComponentModel.DataAnnotations;

namespace WellnesHubAPI.Models;

public class Workout
{
    [Key]
    public int Id { get; set; }
    public string User { get; set; } = null!;
    public string SessionDate { get; set; } = null!;
    public string Exercise { get; set; } = null!;
    public int DurationMinutes { get; set; }
    public string Intensity { get; set; } = null!;
    public int CaloriesBurned { get; set; }
}