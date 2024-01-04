using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankApp.Identity.Core.Commands;
using BankApp.Identity.Core.Events.Dispatcher;
using BankApp.Identity.Core.Events.DomainEvents;
using BankApp.Identity.Core.Identity.Exceptions;
using BankApp.Identity.Core.Identity.Models;
using BankApp.Identity.Core.Repositories;
using BankApp.Identity.Domain.User;

namespace BankApp.Identity.Core.Identity.Services;

//TODO data validation etc.
public class IdentityService : IIdentityService
{
    private readonly IUserRepository _userRepository;
    private readonly ISaltRepository _saltRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly IJwtTokenHandler _jwtTokenHandler;
    private readonly IEventDispatcher _eventDispatcher;
    // private readonly IRefreshTokenService _refreshTokenService;

    public IdentityService(IUserRepository userRepository, IPasswordManager passwordManager,
        IJwtTokenHandler jwtTokenHandler, ISaltRepository saltRepository, IEventDispatcher eventDispatcher)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _jwtTokenHandler = jwtTokenHandler;
        // _refreshTokenService = refreshTokenService;
        _saltRepository = saltRepository;
        _eventDispatcher = eventDispatcher;
    }

    public async Task<AuthorizationDto> SignInAsync(SignInCommand signInCommand, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(signInCommand.Email);
        if (user is null)
        {
            throw new UserDoesNotExistsException();
        }

        var salt = await _saltRepository.GetSalt(user.Id.Id);
        var isValid = _passwordManager.IsValid(user.Password, signInCommand.Password, salt);
        if (isValid is false)
        {
            throw new IncorrectPasswordException();
        }

        var authorization = _jwtTokenHandler.CreateToken(user.Id, user.Role);
        // authorization.RefreshToken = await _refreshTokenService.CreateAsync(user.Id.Id);
        return authorization;
    }

    public async Task SignUpAsync(SignUpCommand signUpCommand, CancellationToken cancellationToken)
    {
        var userInDb = await _userRepository.GetAsync(signUpCommand.Email);
        if (userInDb is not null)
        {
            throw new EmailAlreadyInUseException();
        }

        var hashedPassword = _passwordManager.Hash(signUpCommand.Password, out var salt);

        var user = new User(signUpCommand.Email, Roles.Client, hashedPassword);
        await _userRepository.AddAsync(user);
        await _saltRepository.AddSaltAsync(new UserSalt { Salt = salt, UserId = user.Id.Id });
        await _userRepository.SaveChangesAsync();
        await _saltRepository.SaveChangesAsync();
        await _eventDispatcher.DispatchAsync(user.DomainEvents.Select(@event => @event.MapToPublicEvent()),
            cancellationToken);
    }
}