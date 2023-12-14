namespace BankApp.Identity.Core.Commands;

public record UseRefreshTokenCommand(string RefreshToken) : ICommand;