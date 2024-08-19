using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Repositories;

namespace MishFit.Services;

public class TrackersService : ITrackersService
{
    private readonly ITrackersRepository _trackersRepository;

    public TrackersService(ITrackersRepository trackersRepository)
    {
        _trackersRepository = trackersRepository;
    }

    public async Task<List<Tracker>> GetAllTrackersAsync()
    {
        return await _trackersRepository.GetAllTrackersAsync();
    }

    public async Task<Tracker> GetTrackerByIdAsync(Guid id)
    {
        return await _trackersRepository.GetTrackerByIdAsync(id);
    }

    public async Task<List<Tracker>> GetTrackerHistoryAsync(TrackerHistoryContract contract, string token)
    {
        return await _trackersRepository.GetTrackerHistory(contract, token);
    }

    public async Task<Tracker> AddCalorieTrackerAsync(CreateCalorieTrackerContract contract, string token)
    {
        return await _trackersRepository.AddCalorieTracker(contract, token);
    }

    public async Task<Tracker> AddActivityTrackerAsync(CreateActivityTrackerContract contract, string token)
    {
        return await _trackersRepository.AddActivityTracker(contract, token);
    }

    public async Task<Tracker> AddSleepTrackerAsync(CreateSleepTrackerContract contract, string token)
    {
        return await _trackersRepository.AddSleepTracker(contract, token);
    }

    public async Task<Tracker> UpdateSleepQualityAsync(UpdateSleepTrackerContract contract)
    {
        return await _trackersRepository.UpdateSleepQuality(contract);
    }

    public async Task<Tracker> DeleteTrackerAsync(Guid trackerId)
    {
        return await _trackersRepository.DeleteTracker(trackerId);
    }
}