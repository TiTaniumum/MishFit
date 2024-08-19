using MishFit.Contracts;
using MishFit.Entities;

namespace MishFit.Services;

public interface IMealsService
{
    Task<List<Meal>> GetAllMealsAsync();
    Task<Meal> GetMealByIdAsync(Guid id);
    Task<Meal> CreateMealAsync(CreateMealContract contract);
    Task<Meal> UpdateMealAsync(UpdateMealContract contract);
    Task<Meal> DeleteMealByIdAsync(Guid id);
}