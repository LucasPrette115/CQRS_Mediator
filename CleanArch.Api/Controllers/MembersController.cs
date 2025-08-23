using CleanArch.Domain.Abstractions.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MembersController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var members = await _unitOfWork.MemberRepository.GetAllAsync();
            return Ok(members);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var member = await _unitOfWork.MemberRepository.GetByIdAsync(id);
            if (member == null) return NotFound();
            return Ok(member);
        }       
        
    }
}
