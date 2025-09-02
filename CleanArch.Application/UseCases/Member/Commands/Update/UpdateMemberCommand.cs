using CleanArch.Application.Common;
using Mediator.Abstractions;

namespace CleanArch.Application.UseCases.Member.Commands.Update
{
    public class UpdateMemberCommand : IRequest<Result<UpdateMemberResponse>>
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public bool? IsActive { get; set; }
    }
}
