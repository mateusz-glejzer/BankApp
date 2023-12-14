namespace BankApp.Identity.Core.Services;

public interface IPasswordManager
{
    bool IsValid(string hashedPassword, string password);
    string Hash(string password);
}