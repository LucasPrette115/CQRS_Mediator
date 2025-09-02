using CleanArch.Application.Common;
using CleanArch.Domain.Common;
using Mediator.Abstractions;

namespace CleanArch.Application.UseCases.Member.Queries.Get
{
    public class GetMembersQuery : IRequest<PagedResult<GetMembersResponse>>
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public bool? IsActive { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;        
        public bool NonPaged { get; set; } = false;

    }
}
