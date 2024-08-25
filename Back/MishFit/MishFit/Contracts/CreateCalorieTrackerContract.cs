using System.ComponentModel.DataAnnotations;

namespace MishFit.Contracts;

public record CreateCalorieTrackerContract(
    [Required(ErrorMessage = "MealId is required.")]
    long MealId,
    [Required(ErrorMessage = "MealGrams is required.")]
    int MealGrams
);