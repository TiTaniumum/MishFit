using MishFit.Entities;

namespace MishFit.Repositories;

public interface IMealsTypesRepository
{
    Task<MealType> GetMealTypeById(Guid id);
}