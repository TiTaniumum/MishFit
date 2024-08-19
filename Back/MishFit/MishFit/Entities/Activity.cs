using System.ComponentModel.DataAnnotations.Schema;
using MishFit.Contracts;
using MishFit.Enums;

namespace MishFit.Entities;


public class Activity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ActivityType ActivityType { get; set; }

    public int Calories { get; set; } = 0;

    private Activity()
    {
    }

    public Activity(CreateActivityContract contract)
    {
        Id = Guid.NewGuid();
        Name = contract.Name;
        ActivityType = contract.ActivityType;
        Calories = contract.Calories;
    }
}