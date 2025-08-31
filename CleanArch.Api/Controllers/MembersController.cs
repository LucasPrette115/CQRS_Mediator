using CleanArch.Domain.Abstractions.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MembersController(IMemberRepository memberRepository) : ControllerBase
    {
        private readonly IMemberRepository _memberRepository = memberRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var members = await _memberRepository.GetAllAsync();
            return Ok(members);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            if (member == null) return NotFound();
            return Ok(member);
        }       
        
    }
}
