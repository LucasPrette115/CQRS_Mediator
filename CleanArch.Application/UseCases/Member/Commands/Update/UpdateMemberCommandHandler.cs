using CleanArch.Application.Common;
using CleanArch.Application.UseCases.Member.Factories;
using CleanArch.Domain.Abstractions.Repositories;
using Mediator.Abstractions;

namespace CleanArch.Application.UseCases.Member.Commands.Update
{
    public class UpdateMemberCommandHandler(IMemberRepository memberRepository, IUnitOfWork unitOfWork) : IHandler<UpdateMemberCommand, Result<UpdateMemberResponse>>
    {
        private readonly IMemberRepository _memberRepository = memberRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Result<UpdateMemberResponse>> HandleAsync(UpdateMemberCommand request, CancellationToken cancellation = default)
        {
            try
            {
                var member = await _memberRepository.GetByIdAsync(request.Id) ?? throw new ArgumentNullException("Member not found");

                var memberUpdate = new Domain.Entities.Member(
                    request.Id, 
                    request.FirstName, 
                    request.LastName, 
                    request.Email,
                    member.Password,
                    request.Gender, 
                    request.IsActive);

                _memberRepository.Update(memberUpdate);
                await _unitOfWork.CommitAsync(cancellation);
                return Result<UpdateMemberResponse>.Ok(MemberResponseFactory.MapUpdateResponse(memberUpdate));
            }
            catch (Exception e)
            {
                return Result<UpdateMemberResponse>.Fail(e.Message);
            }
        }
    }
    
}
