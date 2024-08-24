using AutoMapper;
using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Repositories;
using MishFit.Responses;
using MishFit.Profiles;
using MishFit.Profiles;

namespace MishFit.Services;

public class TrackersService : ITrackersService
{
    private readonly ITrackersRepository _trackersRepository;
    private readonly IMapper _mapper;

    public TrackersService(ITrackersRepository trackersRepository, IMapper mapper)
    {
        _trackersRepository = trackersRepository;
        _mapper = mapper;
    }

    public async Task<List<TrackerResponse>> GetAllTrackersAsync()
    {
        return _mapper.Map<List<TrackerResponse>>(await _trackersRepository.GetAllTrackersAsync());
    }

    public async Task<TrackerResponse> GetTrackerByIdAsync(long id)
    {
        return _mapper.Map<TrackerResponse>(await _trackersRepository.GetTrackerByIdAsync(id));
    }

    public async Task<List<TrackerResponse>> GetTrackerHistoryAsync(TrackerHistoryContract contract, string token)
    {
        return _mapper.Map<List<TrackerResponse>>(await _trackersRepository.GetTrackerHistory(contract, token));
    }

    public async Task<TrackerResponse> AddCalorieTrackerAsync(CreateCalorieTrackerContract contract, string token)
    {
        return _mapper.Map<TrackerResponse>(await _trackersRepository.AddCalorieTracker(contract, token));
    }

    public async Task<TrackerResponse> AddActivityTrackerAsync(CreateActivityTrackerContract contract, string token)
    {
        return _mapper.Map<TrackerResponse>(await _trackersRepository.AddActivityTracker(contract, token));
    }

    public async Task<TrackerResponse> AddSleepTrackerAsync(CreateSleepTrackerContract contract, string token)
    {
        return _mapper.Map<TrackerResponse>(await _trackersRepository.AddSleepTracker(contract, token));
    }

    public async Task<TrackerResponse> UpdateSleepQualityAsync(UpdateSleepTrackerContract contract)
    {
        return _mapper.Map<TrackerResponse>(await _trackersRepository.UpdateSleepQuality(contract));
    }

    public async Task<TrackerResponse> DeleteTrackerAsync(long trackerId)
    {
        return _mapper.Map<TrackerResponse>(await _trackersRepository.DeleteTracker(trackerId));
    }
}