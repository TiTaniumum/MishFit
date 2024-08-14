using MishFit.Contracts;
using MishFit.Entities;

namespace MishFit.Repositories;

public class NutritionsRepository : INutritionsRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMealsTypesRepository _mealsTypesRepository;

    public NutritionsRepository(ApplicationDbContext context, IMealsTypesRepository mealsTypesRepository)
    {
        _context = context;
        _mealsTypesRepository = mealsTypesRepository;
    }

    public async Task<Nutrition> CreateNutritionAsync(CreateNutritionContract contract)
    {
        var mealType = await _mealsTypesRepository.GetMealTypeById(contract.MealTypeId);

        return null;
    }
}