using CleanArch.Application.UseCases.Member.Factories;
using CleanArch.Domain.Abstractions.Repositories;
using CleanArch.Domain.Common;
using Mediator.Abstractions;
using System.Linq.Expressions;

namespace CleanArch.Application.UseCases.Member.Queries.Get
{
    public class GetMembersQueryHandler(IMemberRepository memberRepository): IHandler<GetMembersQuery, PagedResult<GetMembersResponse>>
    {
        private readonly IMemberRepository _memberRepository = memberRepository;
        public Task<PagedResult<GetMembersResponse>> HandleAsync(GetMembersQuery request, CancellationToken cancellation = default)
        {
            if (request.PageNumber <= 0 || request.PageSize <= 0)
                throw new ArgumentException("Page Number and Page Size must be greater than zero.");

            Expression<Func<Domain.Entities.Member, bool>> filter = m =>
                (request.Id == Guid.Empty || m.Id == request.Id) &&
                (string.IsNullOrEmpty(request.FirstName) || m.FirstName!.Contains(request.FirstName)) &&
                (string.IsNullOrEmpty(request.LastName) || m.LastName!.Contains(request.LastName)) &&
                (string.IsNullOrEmpty(request.Email) || m.Email!.Contains(request.Email)) &&
                (string.IsNullOrEmpty(request.Gender) || m.Equals(request.Gender)) &&
                (!request.IsActive.HasValue || m.IsActive == request.IsActive);

            return _memberRepository.FilterAllAsync(filter, request.PageNumber, request.PageSize, request.NonPaged)
                .ContinueWith(t => new PagedResult<GetMembersResponse>(
                    t.Result.PageNumber,
                    t.Result.PageSize,
                    t.Result.TotalRecords,
                    t.Result.NonPaged,
                    [.. t.Result.Result.Select(m => MemberResponseFactory.MapGetResponse(m))]), cancellation);

        }
    }
}
