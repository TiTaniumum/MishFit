using MishFit.Contracts;
using MishFit.Entities;

namespace MishFit.Services;

public interface IMealsService
{
    Task<List<Meal>> GetAllMealsAsync();
    Task<Meal> GetMealByIdAsync(long id);
    Task<Meal> CreateMealAsync(CreateMealContract contract);
    Task<Meal> UpdateMealAsync(UpdateMealContract contract);
    Task<Meal> DeleteMealByIdAsync(long id);
}