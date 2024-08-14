namespace MishFit.Entities;

public class MealType
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }

    private MealType()
    {
    }
    
}