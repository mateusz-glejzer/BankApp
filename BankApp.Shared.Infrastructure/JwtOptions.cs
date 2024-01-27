namespace BankApp.Shared.Infrastructure;

public class JwtOptions
{
    public string IssuerSigningKey { get; set; }
    public string ValidIssuer { get; set; }
    public string Algorithm { get; set; }
    public long ExpiryInSeconds { get; set; }
}