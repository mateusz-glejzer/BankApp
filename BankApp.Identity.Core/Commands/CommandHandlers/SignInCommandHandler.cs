using System.Threading;
using System.Threading.Tasks;
using BankApp.Identity.Core.Identity.Models;
using BankApp.Identity.Core.Identity.Services;

namespace BankApp.Identity.Core.Commands.CommandHandlers;

public class SignInCommandHandler : ICommandHandler<SignInCommand, AuthorizationDto>
{
    private readonly IIdentityService _identityService;

    public SignInCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<AuthorizationDto> HandleAsync(SignInCommand command,
        CancellationToken cancellationToken = default)
    {
        return await _identityService.SignInAsync(command);
    }
}