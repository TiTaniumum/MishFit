using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Exceptions;

namespace MishFit.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ApplicationDbContext _context;

    public UsersRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id) ??
               throw new ElementNotFoundException($"User with id {id} not found.");
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email) ??
               throw new ElementNotFoundException($"User with email {email} not found.");
        ;
    }

    public async Task<User> AddUserAsync(User user)
    {
        if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            throw new ElementAlreadyExistsException($"User with email ${user.Email} already exists.");

        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> UpdateUserAsync(UpdateUserContract contract)
    {
        var user = await GetUserByIdAsync(contract.Id);

        // if (await _context.Users.AnyAsync(u => u.Email == contract.Email)) // В бд аналитики решили не изменять email
        //     throw new ElementAlreadyExistsException($"User with email ${contract.Email} already exists.");

        user.Sex = contract.Sex ?? user.Sex;
        user.BirthDate = contract.BirthDate ?? user.BirthDate;
        user.Weight = contract.Weight ?? user.Weight;
        user.Height = contract.Height ?? user.Height;
        user.StepsGoal = contract.StepsGoal ?? user.StepsGoal;
        user.WeightGoal = contract.WeightGoal ?? user.WeightGoal;

        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, contract.Password);

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task DeleteUserByIdAsync(Guid id)
    {
        var user = await GetUserByIdAsync(id);

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();
    }
}