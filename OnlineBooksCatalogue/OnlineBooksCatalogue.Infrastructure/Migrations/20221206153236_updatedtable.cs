using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBooksCatalogue.Infrastructure.Migrations
{
    public partial class updatedtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Books_BooksBookId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Users_UserId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_BooksBookId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "BooksBookId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Subscriptions");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubscriptionId",
                table: "Users",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_SubscriptionId",
                table: "Books",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Subscriptions_SubscriptionId",
                table: "Books",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Subscriptions_SubscriptionId",
                table: "Users",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Subscriptions_SubscriptionId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Subscriptions_SubscriptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SubscriptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Books_SubscriptionId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BooksBookId",
                table: "Subscriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Subscriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_BooksBookId",
                table: "Subscriptions",
                column: "BooksBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Books_BooksBookId",
                table: "Subscriptions",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Users_UserId",
                table: "Subscriptions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
