using MishFit.Contracts;

namespace MishFit.Entities;

public class Activity
{
    public Guid Id { get; set; }
    
    public DateTime Time { get; set; }
    
    public string ActivityType { get; set; }
    public int Duration { get; set; }
    
    public int CaloriesBurned { get; set; }
    
    public Activity(){}

    public Activity(CreateActivityContract contract)
    {
        Id=Guid.NewGuid();
        Time = contract.Time;
        ActivityType = contract.ActivityType;
        Duration = contract.Duration;
        CaloriesBurned = contract.CaloriesBurned;
    } 
}