using System.ComponentModel.DataAnnotations;

namespace MishFit.Contracts;

public record CreateSleepTrackerContract(
    [Required(ErrorMessage = "SleepBegin is required.")]
    DateTime SleepBegin,
    [Required(ErrorMessage = "SleepEnd is required.")]
    DateTime SleepEnd
);