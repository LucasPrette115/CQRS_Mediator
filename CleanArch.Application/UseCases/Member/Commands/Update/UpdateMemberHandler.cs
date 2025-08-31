using Mediator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.UseCases.Member.Commands.Update
{
    public class UpdateMemberHandler : IHandler<UpdateMemberCommand, UpdateMemberResponse>
    {
        public Task<UpdateMemberResponse> HandleAsync(UpdateMemberCommand request, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }
    }
    
}
