using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Exceptions;
using MishFit.Repositories;

namespace MishFit.Services;

public class SleepsService: ISleepsService
{
    private readonly ISleepRepository _repository;

    public SleepsService(ISleepRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Sleep>> GetAllSleepsAsync()
    {
        return await _repository.GetAllSleepsAsync();
    }

    public async Task<Sleep> GetSleepByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new InvalidIncomingParameterException($"Sleep id cannot be null.");
        
        return await _repository.GetSleepByIdAsync(id);
    }

    public async Task<Sleep> CreateSleepAsync(CreateSleepContract contract)
    {
        return await _repository.CreateSleepAsync(contract);
    }

    public async Task<Sleep> UpdateSleepAsync(UpdateSleepContract contract)
    {
        return await _repository.UpdateSleepAsync(contract);
    }

    public async Task DeleteSleepByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new InvalidIncomingParameterException($"Sleep id cannot be null.");

        await _repository.DeleteSleepByIdAsync(id);
    }
}