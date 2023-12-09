using BankApp.Identity.Core.Commands;
using BankApp.Identity.Core.Models;

namespace BankApp.Identity.Core.Services;

public interface IIdentityService
{
    Task<IdentityModel> SignInAsync(SignInCommand signInCommand);
    Task SignUpAsync(SignUpCommand signUpCommand);
}