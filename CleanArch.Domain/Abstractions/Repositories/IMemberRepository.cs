using CleanArch.Domain.Common;
using CleanArch.Domain.Entities;
using System.Linq.Expressions;

namespace CleanArch.Domain.Abstractions.Repositories;

public interface IMemberRepository
{
    Task<IEnumerable<Entities.Member>> GetAllAsync();
    Task<PagedResult<Member>> FilterAllAsync(
            Expression<Func<Member, bool>> predicate,
            int? page = null,
            int? pageSize = null,
            bool? nonPaged = null);
    Task<Entities.Member> GetByIdAsync(Guid id);
    Task<Entities.Member> AddAsync(Entities.Member member);
    void Update(Entities.Member member);
    Task<bool> DeleteAsync(Guid id);
}
