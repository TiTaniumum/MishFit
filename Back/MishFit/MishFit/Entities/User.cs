using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Identity;
using MishFit.Contracts;
using MishFit.Enums;

namespace MishFit.Entities;

public class User
{
    public Guid Id { get; set; }

    [MaxLength(100)] public String Email { get; set; } = string.Empty;
    [MaxLength(100)] public String PasswordHash { get; set; } = string.Empty;

    public Sex? Sex { get; set; }
    
    public DateTime? BirthDay { get; set; }

    public decimal? Weight { get; set; }

    public decimal? Height { get; set; }

    public decimal? StepsGoal { get; set; }

    public decimal? WeightGoal { get; set; }
    public DateTime RegistrationDate { get; init; }

    protected User()
    {
    }

    public User(String email, String passwordHash, Sex? sex, DateTime? birthDay, decimal? weight,
        decimal? height, decimal? stepsGoal, decimal? weightGoal)
    {
        Id = Guid.NewGuid();
        Email = email;
        PasswordHash = passwordHash;
        Sex = sex;
        BirthDay = birthDay;
        Weight = weight;
        Height = height;
        StepsGoal = stepsGoal;
        WeightGoal = weightGoal;
        RegistrationDate = DateTime.UtcNow;
    }
}