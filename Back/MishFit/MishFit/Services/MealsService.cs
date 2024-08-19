using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Repositories;

namespace MishFit.Services;

public class MealsService : IMealsService
{
    private readonly IMealsRepository _repository;

    public MealsService(IMealsRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Meal>> GetAllMealsAsync()
    {
        return await _repository.GetAllMealsAsync();
    }

    public async Task<Meal> GetMealByIdAsync(Guid id)
    {
        return await _repository.GetMealByIdAsync(id);
    }

    public async Task<Meal> CreateMealAsync(CreateMealContract contract)
    {
        return await _repository.CreateMealAsync(contract);
    }

    public async Task<Meal> UpdateMealAsync(UpdateMealContract contract)
    {
        return await _repository.UpdateMealAsync(contract);
    }

    public async Task<Meal> DeleteMealByIdAsync(Guid id)
    {
        return await _repository.DeleteMealByIdAsync(id);
    }
}