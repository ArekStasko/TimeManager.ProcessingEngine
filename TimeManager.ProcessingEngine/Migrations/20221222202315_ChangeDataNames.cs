using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeManager.ProcessingEngine.Migrations
{
    public partial class ChangeDataNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activitySet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userSet",
                table: "userSet");

            migrationBuilder.RenameTable(
                name: "userSet",
                newName: "UserRecords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRecords",
                table: "UserRecords",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "TaskRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskRecords", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRecords",
                table: "UserRecords");

            migrationBuilder.RenameTable(
                name: "UserRecords",
                newName: "userSet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userSet",
                table: "userSet",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "activitySet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activitySet", x => x.Id);
                });
        }
    }
}
