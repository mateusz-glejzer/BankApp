namespace BankApp.Identity.Core.Commands;

public record SignInCommand(string Email, string Password) : ICommand;