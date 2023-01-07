using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeManager.ProcessingEngine.Migrations
{
    public partial class AddTaskSetRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskSetRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSetRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskSetRecords_TaskDTO_TaskId",
                        column: x => x.TaskId,
                        principalTable: "TaskDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskSetRecordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskDate_TaskSetRecords_TaskSetRecordId",
                        column: x => x.TaskSetRecordId,
                        principalTable: "TaskSetRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskDate_TaskSetRecordId",
                table: "TaskDate",
                column: "TaskSetRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSetRecords_TaskId",
                table: "TaskSetRecords",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDate");

            migrationBuilder.DropTable(
                name: "TaskSetRecords");

            migrationBuilder.DropTable(
                name: "TaskDTO");
        }
    }
}
