using Microsoft.EntityFrameworkCore;
using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Enums;
using MishFit.Exceptions;
using MishFit.Responses;
using MishFit.Security;

namespace MishFit.Repositories;

public class TrackersesRepository : ITrackersRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IActivitiesRepository _activitiesRepository;
    private readonly IUsersRepository _usersRepository;

    private readonly IMealsRepository _mealsRepository;

    private readonly IJwtProvider _jwtProvider;

    public TrackersesRepository(ApplicationDbContext context, IActivitiesRepository activitiesRepository, IMealsRepository mealsRepository, IJwtProvider jwtProvider,
        IUsersRepository usersRepository)
    {
        _context = context;
        _activitiesRepository = activitiesRepository;
        _mealsRepository = mealsRepository;
        _jwtProvider = jwtProvider;
        _usersRepository = usersRepository;
    }

    public async Task<List<Tracker>> GetAllTrackersAsync()
    {
        return await _context.Trackers.ToListAsync();
    }

    public async Task<Tracker> GetTrackerByIdAsync(long id)
    {
        return (await _context.Trackers.FindAsync(id)) ??
               throw new ElementNotFoundException($"Tracker with id {id} not found.");
    }

    public async Task<List<Tracker>> GetTrackerHistory(TrackerHistoryContract contract, string token)
    {
        var userId = new Guid(
            _jwtProvider.GetUserIdFromToken(token) ?? "");
        
        var filteredTrackers = await _context.Trackers.Where(t =>
            t.User.Id == userId && t.TrackerType == contract.TrackerType && t.TrackerDateTime >= contract.DateFrom &&
            t.TrackerDateTime <= contract.DateTo).ToListAsync();

        return filteredTrackers;
    }
    
    public async Task<Tracker> AddCalorieTracker(CreateCalorieTrackerContract contract, string token)
    {
        var userId = new Guid(
            _jwtProvider.GetUserIdFromToken(token) ?? "");
        var user = await _usersRepository.GetUserByIdAsync(userId);

        var meal = await _mealsRepository.GetMealByIdAsync(contract.MealId);


        var tracker = new Tracker(
            user,
            TrackerType.Calorie,
            meal,
            contract.MealGrams
        );

        await _context.Trackers.AddAsync(tracker);
        await _context.SaveChangesAsync();

        return tracker;
    }

    public async Task<Tracker> AddActivityTracker(CreateActivityTrackerContract contract, string token)
    {
        var userId = new Guid(
            _jwtProvider.GetUserIdFromToken(token) ?? "");
        var user = await _usersRepository.GetUserByIdAsync(userId);
        
        var activity = await _activitiesRepository.GetActivityByIdAsync(contract.ActivityId);
        
        var tracker = new Tracker(
            user,
            TrackerType.Activity,
            activity,
            contract.ActivityType,
            contract.ActivityTimespan,
            contract.ActivitySets,
            contract.ActivityRepetitions
        );

        await _context.Trackers.AddAsync(tracker);
        await _context.SaveChangesAsync();

        return tracker;
    }
    
    public async Task<Tracker> AddSleepTracker(CreateSleepTrackerContract contract, string token)
    {
        var userId = new Guid(
            _jwtProvider.GetUserIdFromToken(token) ?? "");
        var user = await _usersRepository.GetUserByIdAsync(userId);

        var tracker = new Tracker(
            user,
            TrackerType.Sleep,
            contract.SleepBegin,
            contract.SleepEnd
        );
        await _context.Trackers.AddAsync(tracker);
        await _context.SaveChangesAsync();

        return tracker;
    }

    public async Task<Tracker> UpdateSleepQuality(UpdateSleepTrackerContract contract)
    {
        var tracker = await GetTrackerByIdAsync(contract.TrackerId);
        tracker.SleepQuality = contract.SleepQuality;

        await _context.SaveChangesAsync();
        return tracker;
    }

    public async Task<Tracker> DeleteTracker(long trackerId)
    {
        var tracker = await GetTrackerByIdAsync(trackerId);
        tracker.DeleteDateTime = DateTime.UtcNow;
        
        await _context.SaveChangesAsync();
        return tracker;
    }
}