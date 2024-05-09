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
                name: "farmers",
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
                    table.PrimaryKey("PK_farmers", x => x.fID);
                });

            migrationBuilder.CreateTable(
                name: "crops",
                columns: table => new
                {
                    cID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cNAme = table.Column<string>(type: "TEXT", nullable: false),
                    sun = table.Column<int>(type: "INTEGER", nullable: false),
                    temp = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    avYeild = table.Column<double>(type: "REAL", nullable: false),
                    fID = table.Column<int>(type: "INTEGER", nullable: false),
                    FarmerfID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crops", x => x.cID);
                    table.ForeignKey(
                        name: "FK_crops_farmers_FarmerfID",
                        column: x => x.FarmerfID,
                        principalTable: "farmers",
                        principalColumn: "fID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_crops_FarmerfID",
                table: "crops",
                column: "FarmerfID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "crops");

            migrationBuilder.DropTable(
                name: "farmers");
        }
    }
}
