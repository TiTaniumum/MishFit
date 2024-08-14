using MishFit.Contracts;
using MishFit.Entities;

namespace MishFit.Services;

public interface ISleepsService
{
    public Task<List<Sleep>> GetAllSleepsAsync();

    public Task<Sleep> GetSleepByIdAsync(Guid id);

    public Task<Sleep> CreateSleepAsync(CreateSleepContract contract);
    public Task<Sleep> UpdateSleepAsync(UpdateSleepContract contract);

    public Task DeleteSleepByIdAsync(Guid id);
}