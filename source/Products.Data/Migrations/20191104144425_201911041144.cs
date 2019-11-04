using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Data.SqlServer.Migrations
{
    public partial class _201911041144 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "Products",
                table: "Products");

            migrationBuilder.DeleteData(
                schema: "Products",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                schema: "Products",
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 6, "Audio" });

            migrationBuilder.InsertData(
                schema: "Products",
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 7, "Video" });

            migrationBuilder.InsertData(
                schema: "Products",
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 8, "Kids" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "Products",
                table: "Products",
                column: "CategoryId",
                principalSchema: "Products",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "Products",
                table: "Products");

            migrationBuilder.DeleteData(
                schema: "Products",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Products",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Products",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.InsertData(
                schema: "Products",
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "Notebooks" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "Products",
                table: "Products",
                column: "CategoryId",
                principalSchema: "Products",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
