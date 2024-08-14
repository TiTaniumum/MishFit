using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Exceptions;
using MishFit.Repositories;

namespace MishFit.Services;

public class ActivitiesService
{
    private readonly IActivitiesRepository _repository;

    public ActivitiesService(IActivitiesRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Activity>> GetAllActivitiesAsync()
    {
        return await _repository.GetAllActivitiesAsync();
    }

    public async Task<Activity> GetActivityByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new InvalidIncomingParameterException($"Activity id cannot be null.");
        
        return await _repository.GetActivityByIdAsync(id);
    }

    public async Task<Activity> CreateActivityAsync(CreateActivityContract contract)
    {
        return await _repository.CreateActivityAsync(contract);
    }

    public async Task<Activity> UpdateActivityAsync(UpdateActivityContract contract)
    {
        return await _repository.UpdateActivityAsync(contract);
    }

    public async Task DeleteActivityByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new InvalidIncomingParameterException($"Activity id cannot be null.");

        await _repository.DeleteActivityByIdAsync(id);
    }
}