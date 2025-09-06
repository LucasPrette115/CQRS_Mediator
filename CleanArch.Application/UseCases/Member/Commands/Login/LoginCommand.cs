using CleanArch.Application.Common;
using Mediator.Abstractions;

namespace CleanArch.Application.UseCases.Member.Commands.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<Result<string>>;
   
}
