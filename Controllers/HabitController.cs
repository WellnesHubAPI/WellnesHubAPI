using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WellnesHubAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HabitsController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // GET: api/habits
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Habit>>> GetHabits()
    {
        return await _context.Habits.ToListAsync();
    }

    // GET: api/habits/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Habit>> GetHabit(int id)
    {
        var habit = await _context.Habits.FindAsync(id);
        return habit == null ? NotFound() : habit;
    }

    // POST: api/habits
    [HttpPost]
    public async Task<ActionResult<Habit>> PostHabit(Habit habit)
    {
        _context.Habits.Add(habit);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetHabit), new { id = habit.Id }, habit);
    }

    // PUT: api/habits/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutHabit(int id, Habit habit)
    {
        if (id != habit.Id)
            return BadRequest();

        _context.Entry(habit).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/habits/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteHabit(int id)
    {
        var habit = await _context.Habits.FindAsync(id);
        if (habit == null)
            return NotFound();

        _context.Habits.Remove(habit);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}