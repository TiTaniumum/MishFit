using MishFit.Contracts;
using MishFit.Entities;

namespace MishFit.Repositories;

public interface IMealsRepository
{
    Task<List<Meal>> GetAllMealsAsync();
    Task<Meal> GetMealByIdAsync(long id);
    Task<Meal> CreateMealAsync(CreateMealContract contract);
    Task<Meal> UpdateMealAsync(UpdateMealContract contract);
    Task<Meal> DeleteMealByIdAsync(long id);
}