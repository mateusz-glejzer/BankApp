using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOutboxMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                schema: "identity",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
                schema: "identity",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    SerializedMessage = table.Column<string>(type: "text", nullable: true),
                    MessageType = table.Column<string>(type: "text", nullable: true),
                    Topic = table.Column<string>(type: "text", nullable: true),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProcessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessages", x => x.MessageId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutboxMessages",
                schema: "identity");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                schema: "identity",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
