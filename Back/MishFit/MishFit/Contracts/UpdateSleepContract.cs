using System.ComponentModel.DataAnnotations;

namespace MishFit.Contracts;

public record UpdateSleepContract(
    
    [Required(ErrorMessage = "Id is required.")]
    Guid Id,
    [Required(ErrorMessage = "StartDate is required.")]
    DateTime StartDate,
    [Required(ErrorMessage = "EndDate is required.")]
    DateTime EndDate,
    [Required(ErrorMessage = "Duration is required.")]
    int Duration,
    [Required(ErrorMessage = "Sleep Quality is required.")]
    int SleepQlt
);