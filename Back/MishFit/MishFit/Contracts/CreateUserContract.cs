using System.ComponentModel.DataAnnotations;

namespace MishFit.Contracts;

public record CreateUserContract(
    [Required(ErrorMessage = "Login is required.")]
    [StringLength(30, MinimumLength = 6, ErrorMessage = "Login must be at least 6 characters long.")]
    String Login,
    
    [Required(ErrorMessage = "Username is required.")]
    [StringLength(30, MinimumLength = 6, ErrorMessage = "Username must be at least 6 characters long.")]
    String Username,
    
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
    String Password
);