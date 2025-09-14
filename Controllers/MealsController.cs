using Microsoft.AspNetCore.Mvc;
using WellnesHubAPI.Models;

namespace WellnesHubAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MealsController : ControllerBase
{
    private static readonly List<Meal> Data = [];

    // GET: api/meals
    [HttpGet]
    public ActionResult<IEnumerable<Meal>> Get(string? user, DateTime? entryDate)
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

        return Ok(result.ToList());
    }

    // GET: api/meals/5
    [HttpGet("{id:int}")]
    public ActionResult<Meal> GetById(int id)
    {
        var meal = Data.FirstOrDefault(m => m.Id == id);
        if (meal == null) return NotFound();
        return Ok(meal);
    }

    // POST: api/meals
    [HttpPost]
    public ActionResult<Meal> Create(Meal meal)
    {
        meal.Id = Data.Count == 0 ? 1 : Data.Max(m => m.Id) + 1;

        Data.Add(meal);
        return CreatedAtAction(nameof(GetById), new { id = meal.Id }, meal);
    }

    // PUT: api/meals/5
    [HttpPut("{id:int}")]
    public IActionResult Replace(int id, Meal meal)
    {
        var existing = Data.FirstOrDefault(m => m.Id == id);
        if (existing == null) return NotFound();

        existing.User = meal.User;
        existing.EntryDate = meal.EntryDate;
        existing.FoodName = meal.FoodName;
        existing.Calories = meal.Calories;
        existing.Protein = meal.Protein;
        existing.Carbs = meal.Carbs;
        existing.Fat = meal.Fat;

        return NoContent();
    }

    // DELETE: api/meals/5
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var existing = Data.FirstOrDefault(m => m.Id == id);
        if (existing == null) return NotFound();

        Data.Remove(existing);
        return NoContent();
    }
}
