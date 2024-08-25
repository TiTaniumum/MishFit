using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using MishFit.Enums;

namespace MishFit.Contracts;

public record CreateUserContract(
    [Required(ErrorMessage = "Email is required.")]
    [StringLength(30, MinimumLength = 6, ErrorMessage = "Email must be at least 6 characters long.")]
    String Email,
    
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
    String PasswordHash,
    
    Sex? Sex,
    DateTime? BirthDate,
    decimal? Weight,
    decimal? Height,
    int? StepsGoal,
    decimal? WeightGoal
);
