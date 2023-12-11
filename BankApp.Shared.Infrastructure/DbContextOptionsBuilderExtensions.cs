using System;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace BankApp.Shared.Infrastructure
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static DbContextOptionsBuilder UsePostgreSqlWithCustomMigrationTable<TDbContext>(
            this DbContextOptionsBuilder optionsBuilder,
            string connectionString,
            Action<NpgsqlDbContextOptionsBuilder> npgsqlDbContextOptionsBuilder = null)
            where TDbContext : DbContext
        {
            return optionsBuilder.UseNpgsql(connectionString,
                builder =>
                {
                    builder.MigrationsHistoryTable("__EFMigrationHistory",
                        SchemaNameProvider.GetForDbContext<TDbContext>());
                    npgsqlDbContextOptionsBuilder.Invoke(builder);
                });
        }
    }
}