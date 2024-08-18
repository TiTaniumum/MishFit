using Microsoft.EntityFrameworkCore;
using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Enums;
using MishFit.Exceptions;
using MishFit.Security;

namespace MishFit.Repositories;

public class TrackerRepository : ITrackerRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IActivitiesRepository _activitiesRepository;

    private readonly IMealsRepository _mealsRepository;

    private readonly IJwtProvider _jwtProvider;

    public TrackerRepository(ApplicationDbContext context, IMealsRepository mealsRepository, IJwtProvider jwtProvider)
    {
        _context = context;
        // _activitiesRepository = activitiesRepository;
        _mealsRepository = mealsRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<List<Tracker>> GetAllTrackersAsync()
    {
        return await _context.Trackers.ToListAsync();
    }

    public async Task<Tracker> GetTrackerByIdAsync(Guid id)
    {
        return await _context.Trackers.FindAsync(id) ??
               throw new ElementNotFoundException($"Tracker with id {id} not found.");
    }

    public async Task<List<Tracker>> GetTrackerHistory(TrackerHistoryContract contract, string token)
    {
        var userId = new Guid(
            _jwtProvider.GetUserIdFromToken(token) ?? "");

        var trackers = await GetAllTrackersAsync();

        var filteredTrackers = trackers.FindAll(t =>
            t.UserId == userId && t.TrackerType == contract.TrackerType && t.TrackerDateTime >= contract.DateFrom &&
            t.TrackerDateTime <= contract.DateTo);

        return filteredTrackers;
    }

    public async Task<Tracker?> AddCalorieTracker(CreateCalorieTrackerContract contract, string token)
    {
        var meal = await _mealsRepository.GetMealByIdAsync(contract.MealId);

        var userId = _jwtProvider.GetUserIdFromToken(token);

        //
        // var tracker = new Tracker
        // {
        //     TrackerType = TrackerType.Calorie,
        //     MealId = contract.MealId,
        //     Meal = meal,
        //     MealGrams = contract.MealGrams,
        //     TrackerDateTime = DateTime.Now
        // };
        //
        // await _context.Trackers.AddAsync(tracker);
        // await _context.SaveChangesAsync();
        //
        return null;
    }

    // public async Task<Tracker> AddActivityTracker(CreateActivityTrackerContract contract, string token)
    // {
    //     var activity = await _activitiesRepository.GetActivityByIdAsync(contract.ActivityId);
    //     
    //     var tracker = new Tracker
    //     {
    //         TrackerType = TrackerType.Activity,
    //         
    //         TrackerDateTime = DateTime.Now
    //     };
    // }
}