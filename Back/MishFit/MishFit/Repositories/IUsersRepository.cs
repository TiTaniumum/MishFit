using MishFit.Contracts;
using MishFit.Entities;

namespace MishFit.Repositories;

public interface IUsersRepository
{
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(Guid id);
    Task<User> CreateUserAsync(CreateUserContract contract);
    Task<User> UpdateUserAsync(UpdateUserContract contract);
    Task DeleteUserByIdAsync();
}