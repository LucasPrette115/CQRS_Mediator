using CleanArch.Application.Common;
using Mediator.Abstractions;

namespace CleanArch.Application.UseCases.Member.Commands.Update
{
    public class UpdateMemberCommandHandler : IHandler<UpdateMemberCommand, Result<UpdateMemberResponse>>
    {
        public Task<Result<UpdateMemberResponse>> HandleAsync(UpdateMemberCommand request, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }
    }
    
}
