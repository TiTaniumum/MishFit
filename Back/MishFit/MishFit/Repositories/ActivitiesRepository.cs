using Microsoft.EntityFrameworkCore;
using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Exceptions;

namespace MishFit.Repositories;

public class ActivitiesRepository : IActivitiesRepository
{
    private readonly ApplicationDbContext _context;

    public ActivitiesRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Activity>> GetAllActivitiesAsync()
    {
        return await _context.Activities.ToListAsync();
    }

    public async Task<Activity> GetActivityByIdAsync(Guid id)
    {
        return await _context.Activities.FindAsync(id) ??
               throw new ElementAlreadyExistsException($"Activity with id {id} not found.");
        ;
    }

    public async Task<Activity> CreateActivityAsync(CreateActivityContract contract)
    {
        var activity = new Activity(contract);

        await _context.Activities.AddAsync(activity);

        await _context.SaveChangesAsync();

        return activity;
    }

    public async Task<Activity> UpdateActivityAsync(UpdateActivityContract contract)
    {
        var activity = await GetActivityByIdAsync(contract.Id);

        activity.Name = contract.Name;
        activity.ActivityType = contract.ActivityType;
        activity.Calories = contract.Calories;

        await _context.SaveChangesAsync();

        return activity;
    }

    public async Task DeleteActivityByIdAsync(Guid id)
    {
        var activity = await GetActivityByIdAsync(id);
        _context.Activities.Remove(activity);
    }
}