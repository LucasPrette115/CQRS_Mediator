using System.Linq.Expressions;

namespace CleanArch.Domain.Abstractions.Repositories;

public interface IMemberRepository
{
    Task<IEnumerable<Entities.Member>> GetAllAsync();
    Task<IEnumerable<Entities.Member>> FilterAll(Expression<Func<Entities.Member, bool>> func);
    Task<Entities.Member> GetByIdAsync(Guid id);
    Task<Entities.Member> AddAsync(Entities.Member member);
    void Update(Entities.Member member);
    Task<bool> DeleteAsync(Guid id);
}
