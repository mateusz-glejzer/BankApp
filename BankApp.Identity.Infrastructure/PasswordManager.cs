using System;
using System.Security.Cryptography;
using System.Text;
using BankApp.Identity.Core.Services;

namespace BankApp.Identity.Infrastructure;

public class PasswordManager : IPasswordManager
{
    //TODO to appSettings
    const int KeySize = 64;
    const int Iterations = 350000;
    HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

    public PasswordManager()
    {
    }

    public bool IsValid(string hash, string password, byte[] salt)
    {
        var providedHashedPassword = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, hashAlgorithm, KeySize);
        return CryptographicOperations.FixedTimeEquals(providedHashedPassword, Convert.FromHexString(hash));
    }

    public string Hash(string password, out byte[] salt)
    {
        salt = RandomNumberGenerator.GetBytes(KeySize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            Iterations,
            hashAlgorithm,
            KeySize);
        return Convert.ToHexString(hash);
    }
}