using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentForeignKeyToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_DepartmentId",
                table: "Products",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_departments_DepartmentId",
                table: "Products",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_departments_DepartmentId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DepartmentId",
                table: "Products");
        }
    }
}
