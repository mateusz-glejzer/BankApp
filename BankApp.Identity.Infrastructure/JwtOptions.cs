namespace BankApp.Identity.Infrastructure;

public class JwtOptions
{
    public string IssuerSigningKey { get; set; }
    public string ValidIssuer { get; set; }
    public bool ValidateAudience { get; set; }
    public bool ValidateIssuer { get; set; }
    public bool ValidateLifetime { get; set; }
    public long ExpiryInSeconds { get; set; }
}