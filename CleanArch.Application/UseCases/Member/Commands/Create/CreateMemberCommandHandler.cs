using CleanArch.Application.Abstractions;
using CleanArch.Application.Common;
using CleanArch.Application.UseCases.Member.Factories;
using CleanArch.Domain.Abstractions.Repositories;
using Mediator.Abstractions;

namespace CleanArch.Application.UseCases.Member.Commands.Create
{
    public class CreateMemberCommandHandler(IMemberRepository memberRepository, IPasswordHasher passwordHasher, IUnitOfWork unitOfWork) : IHandler<CreateMemberCommand, Result<CreateMemberResponse>>
    {
        private readonly IMemberRepository _memberRepository = memberRepository;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Result<CreateMemberResponse>> HandleAsync(CreateMemberCommand request, CancellationToken cancellation = default)
        {
            try
            {
                if (EmailExists(request.Email!))
                    return Result<CreateMemberResponse>.Fail("Email already exists");

                if(string.IsNullOrEmpty(request.Password))
                    return Result<CreateMemberResponse>.Fail("Password is required");

                var member = new Domain.Entities.Member(
                    request.FirstName, 
                    request.LastName, 
                    request.Email,
                    _passwordHasher.Hash(request.Password),
                    request.Gender, 
                    request.IsActive);

                await _memberRepository.AddAsync(member);
                await _unitOfWork.CommitAsync(cancellation);
                return Result<CreateMemberResponse>.Ok(MemberResponseFactory.MapCreateResponse(member));
            }
            catch (Exception e)
            {
                return Result<CreateMemberResponse>.Fail(e.Message);
            }
        }
        
        private bool EmailExists(string email)
        {
            var existingMember = _memberRepository.FilterAllAsync(x => x.Email == email && x.IsActive!.Value).Result;
            return existingMember.Result!.Count != 0;
        }
    }
}
