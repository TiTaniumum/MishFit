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
    public String Password { get; set; } = string.Empty;
    
    public DateTime RegistrationDate { get; set; }

    private User()
    {
    }

    public User(CreateUserContract contract)
    {
        Id = Guid.NewGuid();
        Username = contract.Username;
        Login = contract.Login;
        Password = new PasswordHasher<User>().HashPassword(this, contract.Password);
        RegistrationDate = DateTime.UtcNow;
    } 
}