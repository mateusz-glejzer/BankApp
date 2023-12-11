using Microsoft.EntityFrameworkCore.Storage;

namespace BankApp.Shared.Infrastructure
{
    public class DynamicSqlRelationalCommandBuilder : RelationalCommandBuilder
    {
        public DynamicSqlRelationalCommandBuilder(RelationalCommandBuilderDependencies dependencies)
            : base(dependencies)
        {
        }

        public override IRelationalCommand Build()
        {
            string commandText = ToString();
            commandText = "EXECUTE ('" + commandText.Replace("'", "''") + "')";

            return new RelationalCommand(Dependencies, commandText, Parameters);
        }
    }
}
