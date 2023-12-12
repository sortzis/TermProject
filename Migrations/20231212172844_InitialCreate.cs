using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TermProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loyalties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loyalties", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Loyalties",
                columns: new[] { "ID", "City", "Email", "FirstName", "LastName", "PhoneNumber", "State" },
                values: new object[] { 1, "Seattle", "jjohnson@gmail.com", "John", "Johnson", "5559874563", "Washington" });

            migrationBuilder.InsertData(
                table: "Loyalties",
                columns: new[] { "ID", "City", "Email", "FirstName", "LastName", "PhoneNumber", "State" },
                values: new object[] { 2, "Olympia", "rrobertson@gmail.com", "Robert", "Robertson", "5559875823", "Washington" });

            migrationBuilder.InsertData(
                table: "Loyalties",
                columns: new[] { "ID", "City", "Email", "FirstName", "LastName", "PhoneNumber", "State" },
                values: new object[] { 3, "Portland", "richierich@gmail.com", "Richard", "Richardson", "5552584596", "Oregon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loyalties");
        }
    }
}
