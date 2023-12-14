﻿using BankApp.Identity.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Identity.Infrastructure;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }


    public DbSet<User> Users { get; set; }
    // public DbSet<OutboxMessage> OutboxMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users");
    }
}