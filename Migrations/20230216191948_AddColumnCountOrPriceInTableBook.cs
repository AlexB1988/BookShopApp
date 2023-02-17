using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShopApp.Migrations
{
    public partial class AddColumnCountOrPriceInTableBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountToPurchase",
                table: "Books",
                newName: "CountOrPrice");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorsList",
                table: "Books",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountOrPrice",
                table: "Books",
                newName: "CountToPurchase");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorsList",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
