using System.Threading.Tasks;
using BankApp.Identity.Core.Commands;
using BankApp.Identity.Core.Models;
using BankApp.Identity.Core.Repositories;
using BankApp.Identity.Domain.User;

namespace BankApp.Identity.Core.Services;

//TODO data validation etc.
public class IdentityService : IIdentityService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly IJwtProvider _jwtProvider;
    private readonly IRefreshTokenService _refreshTokenService;

    public IdentityService(IUserRepository userRepository, IPasswordManager passwordManager, IJwtProvider jwtProvider,
        IRefreshTokenService refreshTokenService)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _jwtProvider = jwtProvider;
        _refreshTokenService = refreshTokenService;
    }

    public async Task<AuthorizationDto> SignInAsync(SignInCommand signInCommand)
    {
        var user = await _userRepository.GetAsync(signInCommand.Email);
        var isValid = _passwordManager.IsValid(user.Password, signInCommand.Password);
        if (isValid is false)
        {
        }

        var authorization = _jwtProvider.Create(user.Id.Id, user.Role);
        authorization.RefreshToken = await _refreshTokenService.CreateAsync(user.Id.Id);
        return authorization;
    }

    public async Task SignUpAsync(SignUpCommand signUpCommand)
    {
        var userInDb = await _userRepository.GetAsync(signUpCommand.Email);
        if (userInDb is not null)
        {
            //TODO
        }

        var hashedPassword = _passwordManager.Hash(signUpCommand.Password);
        var user = new User(signUpCommand.Email, "User", hashedPassword);
        await _userRepository.AddAsync(user);
        //TODO message that new user has been created with outbox
    }
}