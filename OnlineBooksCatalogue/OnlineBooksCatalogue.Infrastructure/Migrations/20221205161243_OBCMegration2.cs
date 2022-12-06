using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBooksCatalogue.Infrastructure.Migrations
{
    public partial class OBCMegration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BooksBookId",
                table: "Catalogues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Catalogues_BooksBookId",
                table: "Catalogues",
                column: "BooksBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogues_Books_BooksBookId",
                table: "Catalogues",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogues_Books_BooksBookId",
                table: "Catalogues");

            migrationBuilder.DropIndex(
                name: "IX_Catalogues_BooksBookId",
                table: "Catalogues");

            migrationBuilder.DropColumn(
                name: "BooksBookId",
                table: "Catalogues");
        }
    }
}
