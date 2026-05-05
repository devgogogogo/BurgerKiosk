using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerKiosk.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenuSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { "달콤한 불고기 소스와 신선한 야채", "/Images/bulgogi.png" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { "고소한 체다치즈가 가득한 버거", "/Images/cheese.png" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { "탱글탱글한 새우 패티 버거", "/Images/shrimp.png" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { "시원하고 청량한 코카콜라", "/Images/cola.png" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { "톡 쏘는 청량한 사이다", "/Images/cider.png" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { "바삭하고 짭짤한 감자튀김", "/Images/fries.png" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { "바삭한 튀김옷의 양파링", "/Images/onionring.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImagePath" },
                values: new object[] { "", "" });
        }
    }
}
