namespace BankApp.Identity.Core.Commands;

public record SignUpCommand(string Email, string Password) : ICommand;