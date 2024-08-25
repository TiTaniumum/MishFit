using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Responses;

namespace MishFit.Services;

public interface ITrackersService
{
    Task<List<TrackerResponse>> GetAllTrackersAsync();
    Task<TrackerResponse> GetTrackerByIdAsync(long id);
    Task<List<TrackerResponse>> GetTrackerHistoryAsync(TrackerHistoryContract contract, string token);
    Task<TrackerResponse> AddCalorieTrackerAsync(CreateCalorieTrackerContract contract, string token);
    Task<TrackerResponse> AddActivityTrackerAsync(CreateActivityTrackerContract contract, string token);
    Task<TrackerResponse> AddSleepTrackerAsync(CreateSleepTrackerContract contract, string token);
    Task<TrackerResponse> UpdateSleepQualityAsync(UpdateSleepTrackerContract contract);
    Task<TrackerResponse> DeleteTrackerAsync(long trackerId);
}