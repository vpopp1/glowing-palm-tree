using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace glowing_palm_tree.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    cID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cNAme = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    sun = table.Column<int>(type: "INTEGER", nullable: false),
                    temp = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    avYeild = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.cID);
                });

            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    fID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fName = table.Column<string>(type: "TEXT", nullable: false),
                    address = table.Column<string>(type: "TEXT", nullable: false),
                    avRain = table.Column<double>(type: "REAL", nullable: false),
                    avTemp = table.Column<double>(type: "REAL", nullable: false),
                    CostpUnit = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.fID);
                });

            migrationBuilder.CreateTable(
                name: "productions",
                columns: table => new
                {
                    fID = table.Column<int>(type: "INTEGER", nullable: false),
                    cID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productions", x => new { x.fID, x.cID });
                    table.ForeignKey(
                        name: "FK_productions_Crops_cID",
                        column: x => x.cID,
                        principalTable: "Crops",
                        principalColumn: "cID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productions_Farmers_fID",
                        column: x => x.fID,
                        principalTable: "Farmers",
                        principalColumn: "fID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productions_cID",
                table: "productions",
                column: "cID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productions");

            migrationBuilder.DropTable(
                name: "Crops");

            migrationBuilder.DropTable(
                name: "Farmers");
        }
    }
}
