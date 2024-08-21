using System.ComponentModel.DataAnnotations;
using MishFit.Entities;
using MishFit.Enums;

namespace MishFit.Responses;

public record TrackerResponse(
    [Required(ErrorMessage = "Id is required.")]
    long Id,
    
    [Required(ErrorMessage = "TrackerType is required.")]
    TrackerType TrackerType,
    
    Meal? Meal,
    int? MealGrams,
    Activity? Activity,
    ActivityType? ActivityType,
    int? ActivityTimespan,
    int? ActivitySets,
    int? ActivityRepetitions,
    DateTime? SleepBegin,
    DateTime? SleepEnd,
    int? SleepQuality,
    DateTime TrackerDateTime,
    DateTime? DeleteDateTime
);