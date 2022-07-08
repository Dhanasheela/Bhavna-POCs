using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactWeBAPI.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    cid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cname = table.Column<string>(type: "varchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.cid);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    pid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pname = table.Column<string>(type: "varchar(60)", nullable: true),
                    price = table.Column<int>(nullable: false),
                    actualcost = table.Column<int>(nullable: false),
                    pimage = table.Column<string>(type: "varchar(100)", nullable: true),
                    Categorycid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.pid);
                    table.ForeignKey(
                        name: "FK_Products_Categories_Categorycid",
                        column: x => x.Categorycid,
                        principalTable: "Categories",
                        principalColumn: "cid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Categorycid",
                table: "Products",
                column: "Categorycid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
