using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShopApp.Migrations
{
    public partial class AddColumnsToBookForCountSellAndCahgePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountOrPrice",
                table: "Books",
                newName: "PriceOfBooksToChange");

            migrationBuilder.AddColumn<int>(
                name: "CountBooksToSell",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountBooksToSell",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "PriceOfBooksToChange",
                table: "Books",
                newName: "CountOrPrice");
        }
    }
}
