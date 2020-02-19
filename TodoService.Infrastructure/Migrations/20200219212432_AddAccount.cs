using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoService.Infrastructure.Migrations
{
    public partial class AddAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TasksTable",
                table: "TasksTable");

            migrationBuilder.RenameTable(
                name: "TasksTable",
                newName: "TableTasks");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "TableTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TableTasks",
                table: "TableTasks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    EditDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TableTasks",
                table: "TableTasks");

            migrationBuilder.DropColumn(
                name: "State",
                table: "TableTasks");

            migrationBuilder.RenameTable(
                name: "TableTasks",
                newName: "TasksTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TasksTable",
                table: "TasksTable",
                column: "Id");
        }
    }
}
