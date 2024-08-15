﻿namespace MishFit.Security;

public class JwtOptions : IJwtOptions
{
    public string SecretKey { get; set; } = string.Empty;

    public int ExpiresHours { get; set; }
}