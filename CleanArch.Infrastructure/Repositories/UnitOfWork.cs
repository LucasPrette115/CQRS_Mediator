using CleanArch.Domain.Abstractions.Repositories;
using CleanArch.Infrastructure.Context;

namespace CleanArch.Infrastructure.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork, IDisposable
    {
        private IMemberRepository? _memberRepository;
        private readonly AppDbContext _context = context;

        public IMemberRepository MemberRepository
        {
            get
            { 
                return _memberRepository ??= new MemberRepository(_context); 
            }
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
