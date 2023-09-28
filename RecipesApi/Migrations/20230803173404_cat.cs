using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesApi.Migrations
{
    /// <inheritdoc />
    public partial class cat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "categoryId",
                table: "Recipe",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_categoryId",
                table: "Recipe",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Category_categoryId",
                table: "Recipe",
                column: "categoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Category_categoryId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_categoryId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Recipe");
        }
    }
}
