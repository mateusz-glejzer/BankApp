using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.BankAccounts.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IgnoreMessageObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                schema: "bankAccounts",
                table: "OutboxMessages",
                newName: "SerializedMessage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SerializedMessage",
                schema: "bankAccounts",
                table: "OutboxMessages",
                newName: "Message");
        }
    }
}
