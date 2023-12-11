using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage;

namespace BankApp.Shared.Infrastructure
{
    public abstract class BaseDesignTimeContextFactory<TDbContext> : IDesignTimeDbContextFactory<TDbContext>
        where TDbContext : DbContext
    {
        private const string DatabaseConnectionString =
            "Host=localhost; Database=bankApp-modular; Username=postgres; Password=matimati2137";


        public TDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TDbContext>();

            builder.UsePostgreSqlWithCustomMigrationTable<TDbContext>(DatabaseConnectionString);

            builder.ReplaceService<IRelationalCommandBuilderFactory, DynamicSqlRelationalCommandBuilderFactory>();

            return DbContextFactoryMethod(builder.Options);
        }

        protected abstract TDbContext DbContextFactoryMethod(DbContextOptions<TDbContext> options);
    }
}