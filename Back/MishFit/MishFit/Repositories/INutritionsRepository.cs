using MishFit.Contracts;
using MishFit.Entities;

namespace MishFit.Repositories;

public interface INutritionsRepository
{
    Task<Nutrition> CreateNutritionAsync(CreateNutritionContract contract);
}