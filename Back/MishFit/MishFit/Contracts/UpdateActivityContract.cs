using System.ComponentModel.DataAnnotations;

namespace MishFit.Contracts;

public record UpdateActivityContract(
    [Required(ErrorMessage = "Id is required.")]
    Guid Id,
    [Required(ErrorMessage = "Time is required.")]
    DateTime Time,
    [Required(ErrorMessage = "ActivityType is required.")]
    string ActivityType,
    [Required(ErrorMessage = "Duration is required.")]
    int Duration,
    [Required(ErrorMessage = "CaloriesBurned is required.")]
    int CaloriesBurned
);