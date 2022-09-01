using Microsoft.EntityFrameworkCore.Migrations;

namespace Supplier.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supplier_Parts",
                columns: table => new
                {
                    partid = table.Column<int>(nullable: false),
                    partname = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    timeperiod = table.Column<int>(nullable: false),
                    sid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier_Parts", x => x.partid);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    supplier_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    feedback = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.supplier_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supplier_Parts");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
