using Microsoft.EntityFrameworkCore;
using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Exceptions;

namespace MishFit.Repositories;

public class MealsRepository : IMealsRepository
{
    private readonly ApplicationDbContext _context;

    public MealsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Meal>> GetAllMealsAsync()
    {
        return await _context.Meals.ToListAsync();
    }

    public async Task<Meal> GetMealByIdAsync(Guid id)
    {
        return await _context.Meals.FindAsync(id) ??
               throw new ElementNotFoundException($"Meal with id {id} not found.");
        ;
    }

    public async Task<Meal> CreateMealAsync(CreateMealContract contract)
    {
        var meal = new Meal(contract);

        await _context.Meals.AddAsync(meal);

        await _context.SaveChangesAsync();

        return meal;
    }

    public async Task<Meal> UpdateMealAsync(UpdateMealContract contract)
    {
        var meal = await GetMealByIdAsync(contract.Id);

        meal.Name = contract.Name;
        meal.Calories = contract.Calories;

        await _context.SaveChangesAsync();

        return meal;
    }

    public async Task DeleteMealByIdAsync(Guid id)
    {
        var meal = await GetMealByIdAsync(id);
        _context.Meals.Remove(meal);
        await _context.SaveChangesAsync();
    }
}