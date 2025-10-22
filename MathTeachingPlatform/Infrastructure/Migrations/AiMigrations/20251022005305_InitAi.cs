using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.AiMigrations
{
    /// <inheritdoc />
    public partial class InitAi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ai_config",
                columns: table => new
                {
                    ConfigId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Temperature = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    MaxTokens = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SettingsJson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ai_config", x => x.ConfigId);
                });

            migrationBuilder.CreateTable(
                name: "ai_history_chat",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ai_history_chat", x => x.ChatId);
                });

            migrationBuilder.CreateTable(
                name: "ai_call_log",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    MatrixId = table.Column<int>(type: "int", nullable: true),
                    RequestText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ai_call_log", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_ai_call_log_ai_config_ConfigId",
                        column: x => x.ConfigId,
                        principalTable: "ai_config",
                        principalColumn: "ConfigId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ai_call_log_ConfigId",
                table: "ai_call_log",
                column: "ConfigId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ai_call_log");

            migrationBuilder.DropTable(
                name: "ai_history_chat");

            migrationBuilder.DropTable(
                name: "ai_config");
        }
    }
}
