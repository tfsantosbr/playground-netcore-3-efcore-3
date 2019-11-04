using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Data.SqlServer.Migrations
{
    public partial class _201911041122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "Products");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories",
                newSchema: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Products",
                schema: "Products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "Products",
                newName: "Categories");
        }
    }
}
