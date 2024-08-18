using System.ComponentModel.DataAnnotations;

namespace MishFit.Contracts;

public record CreateCalorieTrackerContract(
    [Required(ErrorMessage = "MealId is required.")]
    Guid MealId,
    [Required(ErrorMessage = "MealGrams is required.")]
    int MealGrams
);