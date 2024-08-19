using System.ComponentModel.DataAnnotations;

namespace MishFit.Contracts;

public record UpdateSleepTrackerContract(
    [Required(ErrorMessage = "TrackerId is required.")]
    Guid TrackerId,
    
    [Required(ErrorMessage = "SleepQuality is required.")]
    int SleepQuality
);