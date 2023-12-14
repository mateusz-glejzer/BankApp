using System;
using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Identity.Core.Commands.CommandHandlers;

public class SignUpCommandHandler : ICommandHandler<SignUpCommand>
{
    public Task HandleAsync(SignUpCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}