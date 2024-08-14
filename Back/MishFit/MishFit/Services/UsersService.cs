using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Exceptions;
using MishFit.Repositories;

namespace MishFit.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _repository;

    public UsersService(IUsersRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _repository.GetAllUsersAsync();
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new InvalidIncomingParameterException($"User id cannot be null.");
        
        return await _repository.GetUserByIdAsync(id);
    }

    public async Task<User> CreateUserAsync(CreateUserContract contract)
    {
        return await _repository.CreateUserAsync(contract);
    }

    public async Task<User> UpdateUserAsync(UpdateUserContract contract)
    {
        return await _repository.UpdateUserAsync(contract);
    }

    public async Task DeleteUserByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new InvalidIncomingParameterException($"User id cannot be null.");

        await _repository.DeleteUserByIdAsync(id);
    }
}