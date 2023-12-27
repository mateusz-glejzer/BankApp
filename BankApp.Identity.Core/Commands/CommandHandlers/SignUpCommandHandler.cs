using System;
using System.Threading;
using System.Threading.Tasks;
using BankApp.Identity.Core.Identity.Services;

namespace BankApp.Identity.Core.Commands.CommandHandlers;

public class SignUpCommandHandler : ICommandHandler<SignUpCommand>
{
    private readonly IIdentityService _identityService;

    public SignUpCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task HandleAsync(SignUpCommand command, CancellationToken cancellationToken = default)
    {
        await _identityService.SignUpAsync(command);
    }
}