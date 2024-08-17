using System.ComponentModel.DataAnnotations;
using MishFit.Enums;

namespace MishFit.Contracts;

public record UpdateUserContract(
    [Required(ErrorMessage = "Id is required.")]
    Guid Id,
    
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
    String Password,
    
    Sex? Sex,
    DateTime? BirthDate,
    decimal? Weight,
    decimal? Height,
    int? StepsGoal,
    decimal? WeightGoal
);