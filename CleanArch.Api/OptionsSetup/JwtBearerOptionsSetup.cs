using CleanArch.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace CleanArch.Api.OptionsSetup
{
    public class JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions) : IConfigureOptions<JwtBearerOptions>
    {
        private readonly JwtOptions _jwtOptions = jwtOptions.Value;
        public void Configure(JwtBearerOptions options)
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtOptions.Issuer,
                ValidAudience = _jwtOptions.Audience,
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                    System.Text.Encoding.UTF8.GetBytes(_jwtOptions.SecretKey))

            };
        }
    }
}
