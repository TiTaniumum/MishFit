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
    
    public int? ActivityId { get; set; }
    
    public Activity? Activity { get; set; }

    public ActivityType? ActivityType { get; set; }
    
    public int? ActivityTimespan { get; set; }
    
    public int? ActivitySets { get; set; }
    
    public int? ActivityRepetitions { get; set; }
    
    public DateTime? SleepBegin { get; set; }
    
    public DateTime? SleepEnd { get; set; }
    
    public int? SleepQuality { get; set; }
    
    public DateTime TrackerDateTime { get; set; } = DateTime.Now;
    
    public DateTime? DeleteDateTime { get; set; }
    
    private Tracker(){}
    
    
    
}