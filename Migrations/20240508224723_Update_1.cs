using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace glowing_palm_tree.Migrations
{
    /// <inheritdoc />
    public partial class Update_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_crops_farmers_FarmerfID",
                table: "crops");

            migrationBuilder.DropColumn(
                name: "fID",
                table: "crops");

            migrationBuilder.AlterColumn<int>(
                name: "FarmerfID",
                table: "crops",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_crops_farmers_FarmerfID",
                table: "crops",
                column: "FarmerfID",
                principalTable: "farmers",
                principalColumn: "fID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_crops_farmers_FarmerfID",
                table: "crops");

            migrationBuilder.AlterColumn<int>(
                name: "FarmerfID",
                table: "crops",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fID",
                table: "crops",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_crops_farmers_FarmerfID",
                table: "crops",
                column: "FarmerfID",
                principalTable: "farmers",
                principalColumn: "fID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
