using CleanArch.Application.Abstractions;
using CleanArch.Application.Common;
using CleanArch.Domain.Abstractions.Repositories;
using Mediator.Abstractions;

namespace CleanArch.Application.UseCases.Member.Commands.Login
{
    public sealed class LoginCommandHandler(
        IMemberRepository memberRepository,
        IJwtProvider jwtProvider,
        IPasswordHasher passwordHasher
        ) : IHandler<LoginCommand, Result<string>>
    {
        private readonly IMemberRepository _memberRepository = memberRepository;
        private readonly IJwtProvider _jwtProvider = jwtProvider;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;

        public async Task<Result<string>> HandleAsync(LoginCommand request, CancellationToken cancellation = default)
        {   
            Result<string> validationResult = new();
            var member = (await _memberRepository.FilterAllAsync(x => x.Email == request.Email && (bool)x.IsActive!)).Result?.FirstOrDefault();

            if (member is null)
                return Result<string>.Fail("Member not found");

            bool verified = _passwordHasher.Verify(request.Password, member.Password!);

            if (!verified)
                return Result<string>.Fail("Password is incorrect");

            string token = _jwtProvider.GenerateToken(member);

            return Result<string>.Ok(token);
        }
    }
}
