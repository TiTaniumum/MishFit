using MishFit.Contracts;
using MishFit.Entities;

namespace MishFit.Repositories;

public interface IMealsRepository
{
    Task<List<Meal>> GetAllMealsAsync();
    Task<Meal> GetMealByIdAsync(Guid id);
    Task<Meal> CreateMealAsync(CreateMealContract contract);
    Task<Meal> UpdateMealAsync(UpdateMealContract contract);
    Task DeleteMealByIdAsync(Guid id);
}