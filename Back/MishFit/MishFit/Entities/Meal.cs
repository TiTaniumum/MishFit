﻿using System.ComponentModel.DataAnnotations.Schema;
using MishFit.Contracts;

namespace MishFit.Entities;


public class Meal
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Calories { get; set; } = 0;

    private Meal() {}

    public Meal(CreateMealContract contract)
    {
        Id = Guid.NewGuid();
        Name = contract.Name;
        Calories = contract.Calories;
    }
}