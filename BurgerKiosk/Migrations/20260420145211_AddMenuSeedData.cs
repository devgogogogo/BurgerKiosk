using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BurgerKiosk.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Category", "IsAvailable", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "버거", true, "불고기버거", 5000 },
                    { 2, "버거", true, "치즈버거", 4500 },
                    { 3, "버거", true, "새우버거", 4000 },
                    { 4, "음료", true, "콜라", 2000 },
                    { 5, "음료", true, "사이다", 2000 },
                    { 6, "사이드", true, "감자튀김", 2500 },
                    { 7, "사이드", true, "양파링", 2500 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
