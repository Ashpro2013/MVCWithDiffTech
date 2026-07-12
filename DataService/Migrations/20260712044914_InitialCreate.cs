using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartmentName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Dob = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Age", "Dob", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Main St", 20, new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "John Doe", "123-456-7890" },
                    { 2, "456 Oak Ave", 21, new DateTime(2005, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Jane Smith", "987-654-3210" },
                    { 3, "789 Pine Rd", 22, new DateTime(2004, 10, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Bob Johnson", "555-123-4567" },
                    { 4, "321 Elm St", 19, new DateTime(2007, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Alice Williams", "444-555-6666" },
                    { 5, "654 Spruce Ln", 23, new DateTime(2003, 8, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Charlie Brown", "333-444-5555" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
