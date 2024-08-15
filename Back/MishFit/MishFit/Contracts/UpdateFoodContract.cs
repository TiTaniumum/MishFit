namespace MishFit.Contracts;

public record UpdateFoodContract(
    Guid Id,
    string Title,
    int Calories
);