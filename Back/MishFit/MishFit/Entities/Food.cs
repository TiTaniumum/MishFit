using MishFit.Contracts;

namespace MishFit.Entities;

public class Food
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    
    public int Calories { get; set; }
    
    private Food() {}

    public Food(CreateFoodContract contract)
    {
        Id = Guid.NewGuid();
        Title = contract.Title;
        Calories = contract.Calories;
    }
}