using System.ComponentModel.DataAnnotations;
using MishFit.Enums;

namespace MishFit.Contracts;

public record CreateActivityTrackerContract
(
    [Required(ErrorMessage = "ActivityId is required.")]
    Guid ActivityId,
    
    [Required(ErrorMessage = "ActivityType is required.")]
    ActivityType ActivityType,
    
    int ActivityTimespan,
    
    int ActivitySets,
    
    int ActivityRepetitions
    
);