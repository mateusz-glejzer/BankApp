using BankApp.Identity.Core.Models;
using BankApp.Identity.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Identity.Infrastructure;

public class IdentityDbContext : DbContext
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
    }


    public DbSet<User> Users { get; set; }
    public DbSet<UserSalt> Salts { get; set; }
    // public DbSet<OutboxMessage> OutboxMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("identity");
    }
}