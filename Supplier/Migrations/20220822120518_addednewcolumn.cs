using Microsoft.EntityFrameworkCore.Migrations;

namespace Supplier.Migrations
{
    public partial class addednewcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier_Parts",
                table: "Supplier_Parts");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Supplier_Parts",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier_Parts",
                table: "Supplier_Parts",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier_Parts",
                table: "Supplier_Parts");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Supplier_Parts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier_Parts",
                table: "Supplier_Parts",
                column: "partid");
        }
    }
}
