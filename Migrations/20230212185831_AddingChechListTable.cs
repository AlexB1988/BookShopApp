using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShopApp.Migrations
{
    public partial class AddingChechListTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_BookPrice_PricesId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "PricesId",
                table: "Sales",
                newName: "CheckListId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_PricesId",
                table: "Sales",
                newName: "IX_Sales_CheckListId");

            migrationBuilder.CreateTable(
                name: "CheckList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sum = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateOfCheck = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_PriceId",
                table: "Sales",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_BookPrice_PriceId",
                table: "Sales",
                column: "PriceId",
                principalTable: "BookPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_CheckList_CheckListId",
                table: "Sales",
                column: "CheckListId",
                principalTable: "CheckList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_BookPrice_PriceId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_CheckList_CheckListId",
                table: "Sales");

            migrationBuilder.DropTable(
                name: "CheckList");

            migrationBuilder.DropIndex(
                name: "IX_Sales_PriceId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "CheckListId",
                table: "Sales",
                newName: "PricesId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_CheckListId",
                table: "Sales",
                newName: "IX_Sales_PricesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_BookPrice_PricesId",
                table: "Sales",
                column: "PricesId",
                principalTable: "BookPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
