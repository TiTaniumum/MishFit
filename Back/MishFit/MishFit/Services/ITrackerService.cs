using MishFit.Contracts;
using MishFit.Entities;

namespace MishFit.Services;

public interface ITrackerService
{
    Task<List<Tracker>> GetAllTrackersAsync();
    Task<Tracker> GetTrackerByIdAsync(Guid id);
    Task<List<Tracker>> GetTrackerHistoryAsync(TrackerHistoryContract contract, string token);
    Task<Tracker> AddCalorieTrackerAsync(CreateCalorieTrackerContract contract, string token);
    Task<Tracker> AddActivityTrackerAsync(CreateActivityTrackerContract contract, string token);
    Task<Tracker> AddSleepTrackerAsync(CreateSleepTrackerContract contract, string token);
    Task<Tracker> UpdateSleepQualityAsync(UpdateSleepTrackerContract contract);
    Task<Tracker> DeleteTrackerAsync(Guid trackerId);
}