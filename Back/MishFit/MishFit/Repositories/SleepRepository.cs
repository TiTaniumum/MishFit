using Microsoft.EntityFrameworkCore;
using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Exceptions;

namespace MishFit.Repositories;

public class SleepRepository : ISleepRepository
{
    private readonly ApplicationDbContext _context;
    
    public SleepRepository(ApplicationDbContext context) 
    {
        _context = context;
    }
    
    public async Task<List<Sleep>> GetAllSleepsAsync()
    {
        return await _context.Sleeps.ToListAsync();
    }
    
    public async Task<Sleep> GetSleepByIdAsync(Guid id)
    {
        return await _context.Sleeps.FindAsync(id) ?? throw new ElementAlreadyExistsException($"Sleep with id {id} not found.");;
    }

    public async Task<Sleep> CreateSleepAsync(CreateSleepContract contract)
    {

        var sleep = new Sleep(contract);

        await _context.Sleeps.AddAsync(sleep);

        await _context.SaveChangesAsync();

        return sleep;
    }

    public async Task<Sleep> UpdateSleepAsync(UpdateSleepContract contract)
    {
        var sleep = await GetSleepByIdAsync(contract.Id);

        sleep.StartDate = contract.StartDate;
        sleep.EndDate = contract.EndDate;
        sleep.Duration = contract.Duration;
        sleep.SleepQlt = contract.SleepQlt;
        
        await _context.SaveChangesAsync();

        return sleep;
    }

    public async Task DeleteSleepByIdAsync(Guid id)
    {
        var sleep = await GetSleepByIdAsync(id);
        _context.Sleeps.Remove(sleep);
    }
}
