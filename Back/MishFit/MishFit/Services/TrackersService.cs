using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Repositories;
using MishFit.Responses;

namespace MishFit.Services;

public class TrackersService : ITrackersService
{
    private readonly ITrackersRepository _trackersRepository;

    public TrackersService(ITrackersRepository trackersRepository)
    {
        _trackersRepository = trackersRepository;
    }

    public async Task<List<TrackerResponse>> GetAllTrackersAsync()
    {
        return (await _trackersRepository.GetAllTrackersAsync()).Select(t=>t.TrackerToTrackerResponse()).ToList();
    }

    public async Task<TrackerResponse> GetTrackerByIdAsync(long id)
    {
        return (await _trackersRepository.GetTrackerByIdAsync(id)).TrackerToTrackerResponse();
    }

    public async Task<List<TrackerResponse>> GetTrackerHistoryAsync(TrackerHistoryContract contract, string token)
    {
        return (await _trackersRepository.GetTrackerHistory(contract, token)).;
    }

    public async Task<TrackerResponse> AddCalorieTrackerAsync(CreateCalorieTrackerContract contract, string token)
    {
        return await _trackersRepository.AddCalorieTracker(contract, token);
    }

    public async Task<TrackerResponse> AddActivityTrackerAsync(CreateActivityTrackerContract contract, string token)
    {
        return await _trackersRepository.AddActivityTracker(contract, token);
    }

    public async Task<TrackerResponse> AddSleepTrackerAsync(CreateSleepTrackerContract contract, string token)
    {
        return await _trackersRepository.AddSleepTracker(contract, token);
    }

    public async Task<TrackerResponse> UpdateSleepQualityAsync(UpdateSleepTrackerContract contract)
    {
        return await _trackersRepository.UpdateSleepQuality(contract);
    }

    public async Task<TrackerResponse> DeleteTrackerAsync(long trackerId)
    {
        return await _trackersRepository.DeleteTracker(trackerId);
    }
}