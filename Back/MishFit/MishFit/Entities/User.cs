using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using MishFit.Contracts;

namespace MishFit.Entities;

public class User
{
    public Guid Id { get; set; }

    [MaxLength(100)]
    public String Login { get; set; } = string.Empty;

    [MaxLength(100)]
    public String Username { get; set; } = string.Empty;

    [MaxLength(100)]
    public String PasswordHash { get; set; } = string.Empty;
    
    public DateTime RegistrationDate { get; set; }

    private User()
    {
    }

    public User(Guid id, string username,string login ,string passwordHash)
    {
        Id = id;
        Username = username;
        Login = login;
        PasswordHash =passwordHash;
        RegistrationDate = DateTime.UtcNow;
    }

    public static User Create(string userName, string login, string passwordHash)
    {
        return new User(Guid.NewGuid(), userName, login, passwordHash);
    }
    public static User Create(CreateUserContract contract)
    {
        return new User(Guid.NewGuid(), contract.Username, contract.Login, contract.PasswordHash);
    }
}