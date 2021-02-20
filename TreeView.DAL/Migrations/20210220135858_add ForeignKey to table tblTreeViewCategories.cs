using Microsoft.EntityFrameworkCore.Migrations;

namespace TreeView.DAL.Migrations
{
    public partial class addForeignKeytotabletblTreeViewCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "tblTreeViewCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "tblTreeViewCategories",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblTreeViewCategories_categoryId",
                table: "tblTreeViewCategories",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTreeViewCategories_tblTreeViewCategories_categoryId",
                table: "tblTreeViewCategories",
                column: "categoryId",
                principalTable: "tblTreeViewCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblTreeViewCategories_tblTreeViewCategories_categoryId",
                table: "tblTreeViewCategories");

            migrationBuilder.DropIndex(
                name: "IX_tblTreeViewCategories_categoryId",
                table: "tblTreeViewCategories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "tblTreeViewCategories");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "tblTreeViewCategories");
        }
    }
}
