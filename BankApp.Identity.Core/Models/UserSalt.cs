using System;

namespace BankApp.Identity.Core.Models;

public class UserSalt
{
    public Guid UserId { get; set; }
    public byte[] Salt { get; set; }
}