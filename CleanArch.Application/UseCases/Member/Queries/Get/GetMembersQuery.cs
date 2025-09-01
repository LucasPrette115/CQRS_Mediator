using CleanArch.Application.Common;
using CleanArch.Domain.Common;
using Mediator.Abstractions;

namespace CleanArch.Application.UseCases.Member.Queries.Get
{
    public class GetMembersQuery(
        Guid id, 
        string? firstName, 
        string? lastName, 
        string? email, 
        string? gender, 
        bool? isActive        
        ) : IRequest<PagedResult<GetMembersResponse>>
    {
        public Guid Id { get; private set; } = id;
        public string? FirstName { get; private set; } = firstName;
        public string? LastName { get; private set; } = lastName;
        public string? Email { get; private set; } = email;
        public string? Gender { get; private set; } = gender;
        public bool? IsActive { get; private set; } = isActive;
        public int PageNumber { get; private set; } = 1;
        public int PageSize { get; private set; } = 10;        
        public bool NonPaged { get; private set; } = false;

    }
}
