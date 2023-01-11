using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeManager.ProcessingEngine.Migrations
{
    public partial class TaskSetRecordUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AvgExecutionTime",
                table: "TaskSetRecords",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Efficiency",
                table: "TaskSetRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FailedTasks",
                table: "TaskSetRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SuccededTasks",
                table: "TaskSetRecords",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgExecutionTime",
                table: "TaskSetRecords");

            migrationBuilder.DropColumn(
                name: "Efficiency",
                table: "TaskSetRecords");

            migrationBuilder.DropColumn(
                name: "FailedTasks",
                table: "TaskSetRecords");

            migrationBuilder.DropColumn(
                name: "SuccededTasks",
                table: "TaskSetRecords");
        }
    }
}
