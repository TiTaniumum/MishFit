using MishFit.Contracts;
using MishFit.Entities;

namespace MishFit.Repositories;

public interface IActivitiesRepository
{
    public Task<List<Activity>> GetAllActivitiesAsync();
    public Task<Activity> GetActivityByIdAsync(long id);

    public Task<Activity> CreateActivityAsync(CreateActivityContract contract);
    public Task<Activity> UpdateActivityAsync(UpdateActivityContract contract);

    public Task<Activity> DeleteActivityByIdAsync(long id);
}