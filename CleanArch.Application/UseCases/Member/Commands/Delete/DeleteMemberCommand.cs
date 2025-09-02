using CleanArch.Application.Common;
using Mediator.Abstractions;

namespace CleanArch.Application.UseCases.Member.Commands.Create
{
    public class DeleteMemberCommand: IRequest<Result<bool>>
    {
        public DeleteMemberCommand(Guid id) { Id = id; }
        public Guid Id { get; set; }
    }
}
