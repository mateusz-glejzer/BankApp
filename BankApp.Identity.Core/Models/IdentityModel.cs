﻿namespace BankApp.Identity.Core.Models;

public class IdentityModel
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public string Role { get; set; }
    public long Expires { get; set; }
}