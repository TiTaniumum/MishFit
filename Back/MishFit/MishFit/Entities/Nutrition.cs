namespace MishFit.Entities;

public struct Macros
{
    public int Proteins;

    public int Carbohydrates;

    public int Fats;
}

public class Nutrition
{
    public Guid Id { get; set; }
    
    public DateTime MealTime { get; set; }
    
    public MealType MealType { get; set; }

    public List<Food> FoodList { get; set; } = [];

    public int TotalCalories => FoodList?.Sum(f => f.Calories) ?? 0;

    public Macros Macros;
}