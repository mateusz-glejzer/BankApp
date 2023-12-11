using Microsoft.EntityFrameworkCore.Storage;

namespace BankApp.Shared.Infrastructure
{
    /// <summary>
    ///     See: https://github.com/dotnet/efcore/issues/12911.
    /// </summary>
    public class DynamicSqlRelationalCommandBuilderFactory : RelationalCommandBuilderFactory
    {
        public DynamicSqlRelationalCommandBuilderFactory(RelationalCommandBuilderDependencies dependencies)
            : base(dependencies)
        {
        }

        public override IRelationalCommandBuilder Create()
        {
            return new DynamicSqlRelationalCommandBuilder(Dependencies);
        }
    }
}
