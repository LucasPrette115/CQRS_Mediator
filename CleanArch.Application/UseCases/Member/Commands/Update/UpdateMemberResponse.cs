namespace CleanArch.Application.UseCases.Member.Commands.Update
{
    public class UpdateMemberResponse(Guid id, string? firstName, string? lastName, string? email, string? gender, bool? isActive)
    {
        public Guid Id { get; private set; } = id;
        public string? FirstName { get; private set; } = firstName;
        public string? LastName { get; private set; } = lastName;
        public string? Email { get; private set; } = email;
        public string? Gender { get; private set; } = gender;
        public bool? IsActive { get; private set; } = isActive;
    }
}
