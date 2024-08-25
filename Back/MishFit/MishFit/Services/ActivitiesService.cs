using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Exceptions;
using MishFit.Repositories;

namespace MishFit.Services;

public class ActivitiesService : IActivitiesService
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

    public async Task<Activity> GetActivityByIdAsync(long id)
    {
        if (id <= 0)
            throw new InvalidIncomingParameterException($"Activity id cannot be null.");
        
        return await _repository.GetActivityByIdAsync(id);
    }
    
    public async Task<List<Activity>> SearchActivityByNameAsync(string name)
    {
        if (name.Trim()=="")
            throw new InvalidIncomingParameterException($"Activity name cannot be null.");
        
        return await _repository.SearchActivityByNameAsync(name.ToLower().Trim());
    }

    public async Task<Activity> CreateActivityAsync(CreateActivityContract contract)
    {
        return await _repository.CreateActivityAsync(contract);
    }

    public async Task<Activity> UpdateActivityAsync(UpdateActivityContract contract)
    {
        return await _repository.UpdateActivityAsync(contract);
    }

    public async Task<Activity> DeleteActivityByIdAsync(long id)
    {
        if (id <= 0)
            throw new InvalidIncomingParameterException($"Activity id cannot be null.");

        return await _repository.DeleteActivityByIdAsync(id);
    }
}