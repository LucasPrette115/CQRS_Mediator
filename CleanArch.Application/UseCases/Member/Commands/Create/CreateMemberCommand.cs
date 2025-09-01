using CleanArch.Application.Common;
using Mediator.Abstractions;

namespace CleanArch.Application.UseCases.Member.Commands.Create
{
    public class CreateMemberCommand(string? firstName, string? lastName, string? email, string? gender, bool? isActive) : IRequest<Result<CreateMemberResponse>>
    {
        public string? FirstName { get; private set; } = firstName;
        public string? LastName { get; private set; } = lastName;
        public string? Email { get; private set; } = email;
        public string? Gender { get; private set; } = gender;
        public bool? IsActive { get; private set; } = isActive;
    }
}
