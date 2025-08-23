using CleanArch.Domain.Abstractions.Repositories;
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

        public async Task<IEnumerable<Member>> FilterAll(Expression<Func<Member, bool>> func)
        {
            ArgumentNullException.ThrowIfNull(func);
            
            return await _dbSet.Where(func).ToListAsync();
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
