using Microsoft.EntityFrameworkCore;

namespace BankApp.Shared.Infrastructure;

public static class SchemaNameProvider
{
    public static string GetForDbContext<TDbContext>()
        where TDbContext : DbContext =>
        typeof(TDbContext).Name.Replace("DbContext", string.Empty);
}
