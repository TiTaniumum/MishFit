using MishFit.Contracts;
using MishFit.Entities;

namespace MishFit.Services;

public interface IActivitiesService
{
    Task<List<Activity>> GetAllActivitiesAsync();
    Task<Activity> GetActivityByIdAsync(Guid id);
    Task<Activity> CreateActivityAsync(CreateActivityContract contract);
    Task<Activity> UpdateActivityAsync(UpdateActivityContract contract);
    Task DeleteActivityByIdAsync(Guid id);
}