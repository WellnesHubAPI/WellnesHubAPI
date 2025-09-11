namespace WellnessHubAPI.Models;

public class Meal
{
    public int Id { get; set; }
    public string User { get; set; } = null!;
    public DateTime EntryDate { get; set; }
    public string FoodName { get; set; } = null!;
    public int? Calories { get; set; }
    public double? Protein { get; set; }    
    public double? Carbs { get; set; }      
    public double? Fat { get; set; }        
}