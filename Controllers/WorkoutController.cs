using Microsoft.AspNetCore.Mvc;
using WellnesHubAPI.Models;

namespace WellnesHubAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutsController : ControllerBase
{
    private static readonly List<Workout> Data = [];

    [HttpGet]
    public ActionResult<IEnumerable<Workout>> Get(string? user, string? sessionDate)
    {
        var result = Data.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(user))
        {
            result = result.Where(w =>
                w.User.Contains(user, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(sessionDate))
        {
            result = result.Where(w => w.SessionDate == sessionDate);
        }

        return Ok(result.ToList());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Workout> GetById(int id)
    {
        var workout = Data.FirstOrDefault(w => w.Id == id);
        if (workout == null) return NotFound();
        return Ok(workout);
    }

    [HttpPost]
    public ActionResult<Workout> Create(Workout workout)
    {
        // Auto-generate Id if not set
        workout.Id = Data.Count == 0 ? 1 : Data.Max(w => w.Id) + 1;

        Data.Add(workout);
        return CreatedAtAction(nameof(GetById), new { id = workout.Id }, workout);
    }

    [HttpPut("{id:int}")]
    public IActionResult Replace(int id, Workout workout)
    {
        var existing = Data.FirstOrDefault(w => w.Id == id);
        if (existing == null) return NotFound();

        existing.User = workout.User;
        existing.SessionDate = workout.SessionDate;
        existing.Exercise = workout.Exercise;
        existing.DurationMinutes = workout.DurationMinutes;
        existing.Intensity = workout.Intensity;
        existing.CaloriesBurned = workout.CaloriesBurned;

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var existing = Data.FirstOrDefault(w => w.Id == id);
        if (existing == null) return NotFound();

        Data.Remove(existing);
        return NoContent();
    }
}
