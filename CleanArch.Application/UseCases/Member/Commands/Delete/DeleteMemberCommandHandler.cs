using CleanArch.Application.Common;
using CleanArch.Domain.Abstractions.Repositories;
using Mediator.Abstractions;

namespace CleanArch.Application.UseCases.Member.Commands.Create
{
    public class DeleteMemberCommandHandler(IMemberRepository memberRepository, IUnitOfWork unitOfWork) : IHandler<DeleteMemberCommand, Result<bool>>
    {
        private readonly IMemberRepository _memberRepository = memberRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork; 
        public async Task<Result<bool>> HandleAsync(DeleteMemberCommand request, CancellationToken cancellation)
        {           
            try
            {
                var member = await _memberRepository.GetByIdAsync(request.Id) ?? throw new ArgumentNullException("Member not found");
                member.Delete();
                _memberRepository.Update(member);
                await _unitOfWork.CommitAsync(cancellation);
                return Result<bool>.Ok(true);
            }
            catch (Exception e)
            {
                return Result<bool>.Fail($"Error deleting member: {e.Message}");
            }
        }
    }
}
