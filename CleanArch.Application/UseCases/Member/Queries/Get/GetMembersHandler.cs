using Mediator.Abstractions;

namespace CleanArch.Application.UseCases.Member.Queries.Get
{
    public class GetMembersHandler : IHandler<GetMembersQuery, GetMembersResponse>
    {
        public Task<GetMembersResponse> HandleAsync(GetMembersQuery request, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }
    }
}
