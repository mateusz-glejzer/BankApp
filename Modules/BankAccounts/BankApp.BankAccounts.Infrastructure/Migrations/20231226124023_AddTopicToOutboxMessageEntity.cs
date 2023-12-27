using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.BankAccounts.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTopicToOutboxMessageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Topic",
                schema: "bankAccounts",
                table: "OutboxMessages",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Topic",
                schema: "bankAccounts",
                table: "OutboxMessages");
        }
    }
}
