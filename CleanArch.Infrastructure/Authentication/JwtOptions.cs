namespace CleanArch.Infrastructure.Authentication
{
    public class JwtOptions
    {
        public string SecretKey { get; init; } 
        public string Issuer { get; init; } 
        public string Audience { get; init; }
        public int ExpiryMinutes { get; init; }
    }
}
