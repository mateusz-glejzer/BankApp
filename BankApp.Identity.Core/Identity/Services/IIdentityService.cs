using System.Threading.Tasks;
using BankApp.Identity.Core.Commands;
using BankApp.Identity.Core.Identity.Models;

namespace BankApp.Identity.Core.Identity.Services;

public interface IIdentityService
{
    Task<AuthorizationDto> SignInAsync(SignInCommand signInCommand);
    Task SignUpAsync(SignUpCommand signUpCommand);
}