using MishFit.Entities;

namespace MishFit.Security;

public interface IJwtProvider
{
    string GenerateToken(User user);

    string? GetUserIdFromToken(string token);
}