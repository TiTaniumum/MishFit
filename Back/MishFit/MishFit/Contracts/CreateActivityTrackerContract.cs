using System.ComponentModel.DataAnnotations;
using MishFit.Enums;

namespace MishFit.Contracts;

public record CreateActivityTrackerContract
(
    [Required(ErrorMessage = "ActivityId is required.")]
    Guid ActivityId,
    
    [Required(ErrorMessage = "ActivityType is required.")]
    ActivityType ActivityType,
    
    [Required(ErrorMessage = "ActivityTimespan is required.")]
    int ActivityTimespan,
    
    [Required(ErrorMessage = "ActivitySets is required.")]
    int ActivitySets,
    
    [Required(ErrorMessage = "ActivityRepetitions is required.")]
    int ActivityRepetitions
    
);