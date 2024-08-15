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

    public Task<Nutrition> CreateNutritionAsync(CreateNutritionContract contract)
    {
        // Решил не выполнять, так как потом все равно переписывать.
        throw new NotImplementedException();
    }
}