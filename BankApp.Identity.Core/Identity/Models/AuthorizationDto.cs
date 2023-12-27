using BankApp.Identity.Domain.User;

namespace BankApp.Identity.Core.Identity.Models;

public class AuthorizationDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public Roles Role { get; set; }
    public long Expires { get; set; }
}