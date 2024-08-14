using MishFit.Entities;

namespace MishFit.Contracts;

public record CreateNutritionContract(
    DateTime MealTime,
    Guid MealTypeId,
    List<Guid> FoodIds,
    Macros Macros
);