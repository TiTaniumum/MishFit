using System.ComponentModel.DataAnnotations.Schema;
using MishFit.Enums;

namespace MishFit.Entities;

public class Tracker
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }

    public TrackerType TrackerType { get; set; }

    public Guid? MealId { get; set; }

    public Meal? Meal { get; set; }

    public int? MealGrams { get; set; }

    public Guid? ActivityId { get; set; }

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

    public Tracker(Guid userId, User user, TrackerType trackerType, Guid mealId, Meal meal, int mealGrams)
    {
        UserId = userId;
        User = user;
        TrackerType = trackerType;
        MealId = mealId;
        Meal = meal;
        MealGrams = mealGrams;
        TrackerDateTime = DateTime.UtcNow;
    }

    public Tracker(
        Guid userId,
        User user,
        TrackerType trackerType,
        Guid activityId,
        Activity activity,
        ActivityType activityType,
        int activityTimespan,
        int activitySets,
        int activityRepetitions)
    {
        UserId = userId;
        User = user;
        TrackerType = trackerType;
        ActivityId = activityId;
        Activity = activity;
        ActivityType = activityType;
        ActivityTimespan = activityTimespan;
        ActivitySets = activitySets;
        ActivityRepetitions = activityRepetitions;
        TrackerDateTime = DateTime.UtcNow;
    }

    public Tracker(Guid userId, User user, TrackerType trackerType, DateTime sleepBegin, DateTime sleepEnd)
    {
        UserId = userId;
        User = user;
        TrackerType = trackerType;
        SleepBegin = sleepBegin;
        SleepEnd = sleepEnd;
        TrackerDateTime = DateTime.UtcNow;
    }
}