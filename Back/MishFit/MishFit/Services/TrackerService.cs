using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Repositories;

namespace MishFit.Services;

public class TrackerService : ITrackerService
{
    private readonly ITrackerRepository _trackerRepository;

    public TrackerService(ITrackerRepository trackerRepository)
    {
        _trackerRepository = trackerRepository;
    }

    public async Task<List<Tracker>> GetAllTrackersAsync()
    {
        return await _trackerRepository.GetAllTrackersAsync();
    }

    public async Task<Tracker> GetTrackerByIdAsync(Guid id)
    {
        return await _trackerRepository.GetTrackerByIdAsync(id);
    }

    public async Task<List<Tracker>> GetTrackerHistoryAsync(TrackerHistoryContract contract, string token)
    {
        return await _trackerRepository.GetTrackerHistory(contract, token);
    }

    public async Task<Tracker> AddCalorieTrackerAsync(CreateCalorieTrackerContract contract, string token)
    {
        return await _trackerRepository.AddCalorieTracker(contract, token);
    }

    public async Task<Tracker> AddActivityTrackerAsync(CreateActivityTrackerContract contract, string token)
    {
        return await _trackerRepository.AddActivityTracker(contract, token);
    }

    public async Task<Tracker> AddSleepTrackerAsync(CreateSleepTrackerContract contract, string token)
    {
        return await _trackerRepository.AddSleepTracker(contract, token);
    }

    public async Task<Tracker> UpdateSleepQualityAsync(UpdateSleepTrackerContract contract)
    {
        return await _trackerRepository.UpdateSleepQuality(contract);
    }

    public async Task<Tracker> DeleteTrackerAsync(Guid trackerId)
    {
        return await _trackerRepository.DeleteTracker(trackerId);
    }
}