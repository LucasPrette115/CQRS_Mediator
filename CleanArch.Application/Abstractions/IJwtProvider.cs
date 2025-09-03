using CleanArch.Domain.Entities;

namespace CleanArch.Application.Abstractions
{
    public interface IJwtProvider
    {
        string GenerateToken(Member member);
    }
}
