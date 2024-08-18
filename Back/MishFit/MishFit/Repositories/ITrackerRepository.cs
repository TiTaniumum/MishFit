using MishFit.Contracts;
using MishFit.Entities;

namespace MishFit.Repositories;

public interface ITrackerRepository
{
    Task<Tracker?> AddCalorieTracker(CreateCalorieTrackerContract contract, string token);

    Task<List<Tracker>> GetTrackerHistory(TrackerHistoryContract contract, string token);
}