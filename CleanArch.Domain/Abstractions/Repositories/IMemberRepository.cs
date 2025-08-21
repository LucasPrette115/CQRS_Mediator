using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Abstractions.Repositories;

public interface IMemberRepository
{
    Task<IEnumerable<Entities.Member>> GetAllAsync();
    Task<Entities.Member> GetByIdAsync(Guid id);
    Task<Entities.Member> AddMemberAsync(Entities.Member member);
    Task<Entities.Member> UpdateMemberAsync(Entities.Member member);
    Task DeleteMemberAsync(Guid id);
}
