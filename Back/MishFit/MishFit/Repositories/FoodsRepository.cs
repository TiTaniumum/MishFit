using Microsoft.EntityFrameworkCore;
using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Exceptions;

namespace MishFit.Repositories;

public class FoodsRepository : IFoodsRepository
{
    private readonly ApplicationDbContext _context;

    public FoodsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Food>> GetAllFoodsAsync()
    {
        return await _context.Foods.ToListAsync();
    }

    public async Task<Food> GetFoodByIdAsync(Guid id)
    {
        return await _context.Foods.FindAsync(id) ?? throw new ElementNotFoundException($"Food with id {id} not found.");
    }

    public async Task<Food> CreateFoodAsync(CreateFoodContract contract)
    {
        var food = new Food(contract);

        await _context.Foods.AddAsync(food);

        await _context.SaveChangesAsync();

        return food;
    }

    public async Task<Food> UpdateFoodAsync(UpdateFoodContract contract)
    {
        var food = await GetFoodByIdAsync(contract.Id);

        food.Title = contract.Title;
        food.Calories = contract.Calories;

        await _context.SaveChangesAsync();

        return food;
    }

    public async Task DeleteFoodByIdAsync(Guid id)
    {
        var food = await GetFoodByIdAsync(id);

        _context.Foods.Remove(food);
    }
}