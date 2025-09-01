using CleanArch.Application.UseCases.Member.Commands.Create;
using CleanArch.Application.UseCases.Member.Commands.Update;
using CleanArch.Application.UseCases.Member.Queries.Get;

namespace CleanArch.Application.UseCases.Member.Factories
{
    public static class MemberResponseFactory
    {
        public static CreateMemberResponse MapCreateResponse(Domain.Entities.Member member) =>
            new(member.Id, member.FirstName, member.LastName, member.Email, member.Gender, member.IsActive);

        public static UpdateMemberResponse MapUpdateResponse(Domain.Entities.Member member) =>
            new(member.Id, member.FirstName, member.LastName, member.Email, member.Gender, member.IsActive);

        public static GetMembersResponse MapGetResponse(Domain.Entities.Member member) =>
            new(member.Id, member.FirstName, member.LastName, member.Email, member.Gender, member.IsActive);
    }

}
