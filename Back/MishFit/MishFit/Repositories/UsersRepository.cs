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
        return await _context.Users.FindAsync(id) ?? throw new ElementAlreadyExistsException($"User with id {id} not found.");;
    }

    public async Task<User> CreateUserAsync(CreateUserContract contract)
    {
        if (await _context.Users.AnyAsync(u => u.Login == contract.Login))
            throw new ElementAlreadyExistsException($"User with login ${contract.Login} already exists.");
        //
        //
        //
        //
        
        //
        var user = new User(contract);

        await _context.AddAsync(user);

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> UpdateUserAsync(UpdateUserContract contract)
    {
        var user = await GetUserByIdAsync(contract.Id);

        if (await _context.Users.AnyAsync(u => u.Login == contract.Login))
            throw new ElementAlreadyExistsException($"User with login ${contract.Login} already exists.");

        user.Login = contract.Login;
        user.Username = contract.Username;
        user.Password = new PasswordHasher<User>().HashPassword(user, contract.Password);

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task DeleteUserByIdAsync(Guid id)
    {
        var user = await GetUserByIdAsync(id);

        _context.Users.Remove(user);
    }
}