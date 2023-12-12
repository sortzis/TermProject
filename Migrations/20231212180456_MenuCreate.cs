using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TermProject.Migrations
{
    public partial class MenuCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Loyalties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoyaltyTier = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuId);
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "MenuId", "LoyaltyTier", "Name" },
                values: new object[] { 1, "Newbie", "Breadstix" });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "MenuId", "LoyaltyTier", "Name" },
                values: new object[] { 2, "Novice", "Wings" });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "MenuId", "LoyaltyTier", "Name" },
                values: new object[] { 3, "Veteran", "Pizza" });

            migrationBuilder.UpdateData(
                table: "Loyalties",
                keyColumn: "ID",
                keyValue: 1,
                column: "MenuId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Loyalties",
                keyColumn: "ID",
                keyValue: 2,
                column: "MenuId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Loyalties",
                keyColumn: "ID",
                keyValue: 3,
                column: "MenuId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Loyalties_MenuId",
                table: "Loyalties",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loyalties_Menu_MenuId",
                table: "Loyalties",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loyalties_Menu_MenuId",
                table: "Loyalties");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Loyalties_MenuId",
                table: "Loyalties");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Loyalties");
        }
    }
}
