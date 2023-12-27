namespace BankApp.Identity.Core.Identity.Services;

public interface IPasswordManager
{
    bool IsValid(string hash, string password, byte[] salt);
    string Hash(string password, out byte[] salt);
}