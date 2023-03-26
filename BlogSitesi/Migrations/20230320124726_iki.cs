using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSitesi.Migrations
{
    public partial class iki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KonuMakale_Konu_KonularId",
                table: "KonuMakale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Konu",
                table: "Konu");

            migrationBuilder.RenameTable(
                name: "Konu",
                newName: "Konular");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Konular",
                table: "Konular",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KonuMakale_Konular_KonularId",
                table: "KonuMakale",
                column: "KonularId",
                principalTable: "Konular",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KonuMakale_Konular_KonularId",
                table: "KonuMakale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Konular",
                table: "Konular");

            migrationBuilder.RenameTable(
                name: "Konular",
                newName: "Konu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Konu",
                table: "Konu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KonuMakale_Konu_KonularId",
                table: "KonuMakale",
                column: "KonularId",
                principalTable: "Konu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
