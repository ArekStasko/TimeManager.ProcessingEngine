using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeManager.ProcessingEngine.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Efficiency = table.Column<double>(type: "float", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskSetRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskSetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Efficiency = table.Column<int>(type: "int", nullable: true),
                    FailedTasks = table.Column<int>(type: "int", nullable: true),
                    SuccededTasks = table.Column<int>(type: "int", nullable: true),
                    AvgExecutionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSetRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuccededTasks = table.Column<int>(type: "int", nullable: false),
                    FailedTasks = table.Column<int>(type: "int", nullable: false),
                    AverageTaskDuration = table.Column<int>(type: "int", nullable: false),
                    Effectivity = table.Column<int>(type: "int", nullable: false),
                    Productivity = table.Column<int>(type: "int", nullable: false),
                    TaskCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskSetRecordsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskDate_TaskSetRecords_TaskSetRecordsId",
                        column: x => x.TaskSetRecordsId,
                        principalTable: "TaskSetRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskDate_TaskSetRecordsId",
                table: "TaskDate",
                column: "TaskSetRecordsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDate");

            migrationBuilder.DropTable(
                name: "TaskRecords");

            migrationBuilder.DropTable(
                name: "UserRecords");

            migrationBuilder.DropTable(
                name: "TaskSetRecords");
        }
    }
}
