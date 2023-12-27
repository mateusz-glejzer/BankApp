using System;
using BankApp.Identity.Core.Identity.Models;
using BankApp.Identity.Domain.User;
using BankApp.Identity.Infrastructure.Outbox;
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

    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("identity");
        modelBuilder.Entity<User>().Property(user => user.Id)
            .HasConversion(userId => userId.Id, id => new UserId(id));
        modelBuilder.Entity<UserSalt>().HasKey(a => a.UserId);
        modelBuilder.Entity<User>().Property(user => user.Role)
            .HasConversion(roles => roles.ToString(), a => Enum.Parse<Roles>(a));

        modelBuilder.Entity<OutboxMessage>()
            .HasKey(message => message.MessageId);
        modelBuilder.Entity<OutboxMessage>().Ignore(account => account.Message);
    }
}