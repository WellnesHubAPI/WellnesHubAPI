using Microsoft.AspNetCore.Mvc;
using WellnesHubAPI.Models;

namespace WellnesHubAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoodEntriesController : ControllerBase
{
    private static readonly List<MoodEntry> Data = [];

    // GET: api/moodentries
    [HttpGet]
    public ActionResult<IEnumerable<MoodEntry>> Get(string? user, DateTime? entryDate, string? mood)
    {
        var result = Data.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(user))
        {
            result = result.Where(m =>
                m.User.Contains(user, StringComparison.OrdinalIgnoreCase));
        }

        if (entryDate.HasValue)
        {
            result = result.Where(m => m.EntryDate.Date == entryDate.Value.Date);
        }

        if (!string.IsNullOrWhiteSpace(mood))
        {
            result = result.Where(m =>
                m.Mood != null && m.Mood.Equals(mood, StringComparison.OrdinalIgnoreCase));
        }

        return Ok(result.ToList());
    }

    // GET: api/moodentries/5
    [HttpGet("{id:int}")]
    public ActionResult<MoodEntry> GetById(int id)
    {
        var moodEntry = Data.FirstOrDefault(m => m.Id == id);
        if (moodEntry == null) return NotFound();
        return Ok(moodEntry);
    }

    // POST: api/moodentries
    [HttpPost]
    public ActionResult<MoodEntry> Create(MoodEntry moodEntry)
    {
        moodEntry.Id = Data.Count == 0 ? 1 : Data.Max(m => m.Id) + 1;

        Data.Add(moodEntry);
        return CreatedAtAction(nameof(GetById), new { id = moodEntry.Id }, moodEntry);
    }

    // PUT: api/moodentries/5
    [HttpPut("{id:int}")]
    public IActionResult Replace(int id, MoodEntry moodEntry)
    {
        var existing = Data.FirstOrDefault(m => m.Id == id);
        if (existing == null) return NotFound();

        existing.User = moodEntry.User;
        existing.EntryDate = moodEntry.EntryDate;
        existing.Mood = moodEntry.Mood;
        existing.Energy = moodEntry.Energy;
        existing.SleepHours = moodEntry.SleepHours;
        existing.StressLevel = moodEntry.StressLevel;

        return NoContent();
    }

    // DELETE: api/moodentries/5
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var existing = Data.FirstOrDefault(m => m.Id == id);
        if (existing == null) return NotFound();

        Data.Remove(existing);
        return NoContent();
    }
}
