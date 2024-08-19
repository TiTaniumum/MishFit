using System.ComponentModel.DataAnnotations;

namespace MishFit.Contracts;

public record CreateMealContract(
    [Required(ErrorMessage = "Name is required.")]
    string Name,
    [Required(ErrorMessage = "Calories is required.")]
    int Calories
);