using CleanArch.Application.UseCases.Member.Commands.Create;
using CleanArch.Application.UseCases.Member.Commands.Login;
using CleanArch.Application.UseCases.Member.Commands.Update;
using CleanArch.Application.UseCases.Member.Queries.Get;
using Mediator.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class MembersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("getMembers")]
        public async Task<IActionResult> GetAll([FromQuery] GetMembersQuery request)
        {
            var members = await _mediator.SendAsync(request);
            return Ok(members);
        }
        
        [HttpGet("getMemberById/{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = new GetMembersQuery() { Id = id };
            var result = await _mediator.SendAsync(query);

            if (result.Result == null || result.Result.Count == 0)
                return NotFound();

            return Ok(result.Result);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginMember([FromBody] LoginCommand request)
        {
            var tokenResult = await _mediator.SendAsync(request);

            if (!tokenResult.Success)
                return UnprocessableEntity(tokenResult.Errors);

            return Ok(tokenResult);
        }

        [HttpPost("createMember")]
        public async Task<IActionResult> CreateMember([FromBody] CreateMemberCommand request)
        {
            var member = await _mediator.SendAsync(request);

            if (!member.Success)
                return UnprocessableEntity(member.Errors);

            return Created($"/api/members/{member.Data?.Id}", member);
        }

        [HttpPut("updateMember")]
        public async Task<IActionResult> UpdateMember([FromBody] UpdateMemberCommand request)
        {
            var member = await _mediator.SendAsync(request);

            if (!member.Success)
                return UnprocessableEntity(member.Errors);

            return Ok(member);
        }

        [HttpDelete("deleteMember/{id:guid}")]
        public async Task<IActionResult> DeleteMember([FromRoute] Guid id)
        {
            var command = new DeleteMemberCommand(id);
            var result = await _mediator.SendAsync(command);

            if (!result.Success)
                return UnprocessableEntity(result.Errors);

            return Ok(result);
        }
    }
}
