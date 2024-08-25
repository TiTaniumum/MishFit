using System.ComponentModel.DataAnnotations;
using MishFit.Enums;

namespace MishFit.Contracts;

public record CreateActivityContract(
    
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be at least 3 characters long.")]
    string Name,
    
    [Required(ErrorMessage = "ActivityType is required.")]
    ActivityType ActivityType,
    
    
    [Required(ErrorMessage = "Calories is required.")]
    int Calories
);