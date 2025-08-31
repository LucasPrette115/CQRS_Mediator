using CleanArch.Domain.Abstractions.Repositories;
using CleanArch.Infrastructure.Context;

namespace CleanArch.Infrastructure.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork, IDisposable
    {       
        private readonly AppDbContext _context = context;       

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
