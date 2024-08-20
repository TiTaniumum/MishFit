using MishFit.Contracts;
using MishFit.Entities;

namespace MishFit.Services;

public interface IActivitiesService
{
    Task<List<Activity>> GetAllActivitiesAsync();
    Task<Activity> GetActivityByIdAsync(long id);
    Task<Activity> CreateActivityAsync(CreateActivityContract contract);
    Task<Activity> UpdateActivityAsync(UpdateActivityContract contract);
    Task<Activity> DeleteActivityByIdAsync(long id);
}