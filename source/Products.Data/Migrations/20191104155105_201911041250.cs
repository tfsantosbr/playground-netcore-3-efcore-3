using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Data.SqlServer.Migrations
{
    public partial class _201911041250 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Products",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Products",
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 5, "Games" });
        }
    }
}
