using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MishFit.Enums;

namespace MishFit.Entities;

public class Tracker
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public User User { get; set; }

    public TrackerType TrackerType { get; set; }

    public Meal? Meal { get; set; }

    public int? MealGrams { get; set; }

    public Activity? Activity { get; set; }

    public ActivityType? ActivityType { get; set; }

    public int? ActivityTimespan { get; set; }

    public int? ActivitySets { get; set; }

    public int? ActivityRepetitions { get; set; }

    public DateTime? SleepBegin { get; set; }

    public DateTime? SleepEnd { get; set; }

    public int? SleepQuality { get; set; }

    public DateTime TrackerDateTime { get; set; }

    public DateTime? DeleteDateTime { get; set; }

    private Tracker()
    {
    }

    public Tracker(User user, TrackerType trackerType, Meal meal, int mealGrams)
    {
        User = user;
        TrackerType = trackerType;
        Meal = meal;
        MealGrams = mealGrams;
        TrackerDateTime = DateTime.UtcNow;
    }
    
    public Tracker(
        User user,
        TrackerType trackerType,
        Activity activity,
        ActivityType activityType,
        int? activityTimespan,
        int? activitySets,
        int? activityRepetitions)
    {
        User = user;
        TrackerType = trackerType;
        Activity = activity;
        ActivityType = activityType;
        ActivityTimespan = activityTimespan;
        ActivitySets = activitySets;
        ActivityRepetitions = activityRepetitions;
        TrackerDateTime = DateTime.UtcNow;
    }
    
    public Tracker(User user, TrackerType trackerType, DateTime sleepBegin, DateTime sleepEnd)
    {
        User = user;
        TrackerType = trackerType;
        SleepBegin = sleepBegin;
        SleepEnd = sleepEnd;
        TrackerDateTime = DateTime.UtcNow;
    }
}