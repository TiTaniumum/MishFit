using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Exceptions;
using MishFit.Repositories;

namespace MishFit.Services;

public class FoodsService : IFoodsService
{
    private readonly IFoodsRepository _repository;

    public FoodsService(IFoodsRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Food>> GetAllFoodsAsync()
    {
        return await _repository.GetAllFoodsAsync();
    }

    public async Task<Food> GetFoodByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new InvalidIncomingParameterException($"Food id cannot be null.");
        
        return await _repository.GetFoodByIdAsync(id);
    }

    public async Task<Food> CreateFoodAsync(CreateFoodContract contract)
    {
        return await _repository.CreateFoodAsync(contract);
    }

    public async Task<Food> UpdateFoodAsync(UpdateFoodContract contract)
    {
        return await _repository.UpdateFoodAsync(contract);
    }

    public async Task DeleteFoodByIdAsync(Guid id)
    {
        await _repository.DeleteFoodByIdAsync(id);
    }
}