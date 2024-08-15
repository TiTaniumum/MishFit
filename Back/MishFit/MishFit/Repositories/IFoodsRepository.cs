using MishFit.Contracts;
using MishFit.Entities;

namespace MishFit.Repositories;

public interface IFoodsRepository
{
    Task<List<Food>> GetAllFoodsAsync();
    Task<Food> GetFoodByIdAsync(Guid id);
    Task<Food> CreateFoodAsync(CreateFoodContract contract);
    Task<Food> UpdateFoodAsync(UpdateFoodContract contract);
    Task DeleteFoodByIdAsync(Guid id);
}