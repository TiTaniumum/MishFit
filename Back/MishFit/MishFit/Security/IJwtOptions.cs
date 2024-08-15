namespace MishFit.Security;

public interface IJwtOptions
{
    string SecretKey { get; set; }
    int ExpiresHours { get; set; }
}