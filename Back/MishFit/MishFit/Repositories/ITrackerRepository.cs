using MishFit.Contracts;
using MishFit.Entities;

namespace MishFit.Repositories;

public interface ITrackerRepository
{
    Task<List<Tracker>> GetAllTrackersAsync();
    Task<Tracker> GetTrackerByIdAsync(Guid id);
    Task<List<Tracker>> GetTrackerHistory(TrackerHistoryContract contract, string token);
    Task<Tracker> AddCalorieTracker(CreateCalorieTrackerContract contract, string token);
    Task<Tracker> AddActivityTracker(CreateActivityTrackerContract contract, string token);
    Task<Tracker> AddSleepTracker(CreateSleepTrackerContract contract, string token);
    Task<Tracker> UpdateSleepQuality(UpdateSleepTrackerContract contract);
    Task<Tracker> DeleteTracker(Guid trackerId);
}