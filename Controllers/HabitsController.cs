using Microsoft.AspNetCore.Mvc;
using WellnesHubAPI.Models;

namespace WellnesHubAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HabitsController : ControllerBase
{
    private static readonly List<Habit> Data = [];

    // GET: api/habits
    [HttpGet]
    public ActionResult<IEnumerable<Habit>> Get(string? user, string? status, string? frequency)
    {
        var result = Data.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(user))
        {
            result = result.Where(h =>
                h.User.Contains(user, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            result = result.Where(h =>
                h.Status != null && h.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(frequency))
        {
            result = result.Where(h =>
                h.Frequency != null && h.Frequency.Equals(frequency, StringComparison.OrdinalIgnoreCase));
        }

        return Ok(result.ToList());
    }

    // GET: api/habits/5
    [HttpGet("{id:int}")]
    public ActionResult<Habit> GetById(int id)
    {
        var habit = Data.FirstOrDefault(h => h.Id == id);
        if (habit == null) return NotFound();
        return Ok(habit);
    }

    // POST: api/habits
    [HttpPost]
    public ActionResult<Habit> Create(Habit habit)
    {
        habit.Id = Data.Count == 0 ? 1 : Data.Max(h => h.Id) + 1;

        Data.Add(habit);
        return CreatedAtAction(nameof(GetById), new { id = habit.Id }, habit);
    }

    // PUT: api/habits/5
    [HttpPut("{id:int}")]
    public IActionResult Replace(int id, Habit habit)
    {
        var existing = Data.FirstOrDefault(h => h.Id == id);
        if (existing == null) return NotFound();

        existing.User = habit.User;
        existing.Title = habit.Title;
        existing.Description = habit.Description;
        existing.Frequency = habit.Frequency;
        existing.Status = habit.Status;

        return NoContent();
    }

    // DELETE: api/habits/5
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var existing = Data.FirstOrDefault(h => h.Id == id);
        if (existing == null) return NotFound();

        Data.Remove(existing);
        return NoContent();
    }
}
