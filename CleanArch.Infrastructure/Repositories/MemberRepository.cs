using CleanArch.Domain.Abstractions.Repositories;
using CleanArch.Domain.Common;
using CleanArch.Domain.Entities;
using CleanArch.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArch.Infrastructure.Repositories
{
    public class MemberRepository(AppDbContext context) : IMemberRepository
    {
        protected readonly AppDbContext _context = context;
        private readonly IQueryable<Member> _dbSet = context.Members
            .AsQueryable()
            .Where(x => x.DeletedAt == null);

        public async Task<Member> AddAsync(Member member)
        {
            ArgumentNullException.ThrowIfNull(member);

            await _context.AddAsync(member);
            return member;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var member = await GetByIdAsync(id);
            _context.Remove(member);
            return true;
        }

        public async Task<PagedResult<Member>> FilterAllAsync(
            Expression<Func<Member, bool>> predicate,
            int? page = null,
            int? pageSize = null,
            bool? nonPaged = null)
        {
            ArgumentNullException.ThrowIfNull(predicate);

            var query = _dbSet.Where(predicate);

            var totalCount = await query.CountAsync();
         
            if (nonPaged != true && page.HasValue && pageSize.HasValue)
            {
                query = query
                    .Skip((page.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);
            }

            var items = await query.ToListAsync();
            
            return new PagedResult<Member>(
                page ?? 1,
                pageSize ?? (nonPaged == true ? totalCount : items.Count),
                totalCount,
                nonPaged,
                items);
        }



        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Member> GetByIdAsync(Guid id)
        {
            var member = await _dbSet.FirstOrDefaultAsync(x => x.Id == id) 
                ?? throw new InvalidOperationException("Member not found");

            return member;
        }

        public void Update(Member member)
        {
            ArgumentNullException.ThrowIfNull(member);

            _context.Members.Update(member);
        }
    }
}
