using MishFit.Entities;
using MishFit.Exceptions;

namespace MishFit.Repositories;

public class MealsTypesRepository : IMealsTypesRepository
{
    private ApplicationDbContext _context;

    public MealsTypesRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<MealType> GetMealTypeById(Guid id)
    {
        return await _context.MealTypes.FindAsync(id) ?? throw new ElementNotFoundException($"Meal type with id {id} not  found.");
    }
}