using System.Security.Authentication;
using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Exceptions;
using MishFit.Repositories;
using MishFit.Security;

namespace MishFit.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _repository;

    private readonly IPasswordHasher _passwordHasher;

    private readonly IJwtProvider _jwtProvider;

    public UsersService(IUsersRepository repository, IPasswordHasher hasher, IJwtProvider jwtProvider)
    {
        _repository = repository;
        _passwordHasher = hasher;
        _jwtProvider = jwtProvider;
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

    // public async Task<User> CreateUserAsync(CreateUserContract contract)
    // {
    //     return await _repository.CreateUserAsync(contract);
    // }

    public async Task<User> RegisterUserAsync(RegisterUserContract contract)
    {
        var hashedPassword = _passwordHasher.Generate(contract.Password);

        var user = new User(contract.Email, hashedPassword, contract.Sex, contract.BirthDay, contract.Weight,
            contract.Height,
            contract.StepsGoal, contract.WeightGoal);
        // var createContract = new CreateUserContract(user.Username, user.Login, user.PasswordHash);
        return await _repository.AddUserAsync(user);
    }

    public async Task<TokenResponse> LoginUserAsync(LoginUserContract contract)
    {
        var user = await _repository.GetUserByEmailAsync(contract.Email);

        var result = _passwordHasher.Verify(contract.Password, user.PasswordHash);

        if (!result)
        {
            throw new AuthenticationFailedException("Failed to login! Invalid email or password");
        }

        var token = _jwtProvider.GenerateToken(user);
        return new TokenResponse(token);
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