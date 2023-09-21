using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.Donation1.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeProduct",
                table: "TypeProduct");

            migrationBuilder.RenameTable(
                name: "TypeProduct",
                newName: "TypeProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeProduct",
                table: "TypeProduct",
                column: "TypeProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeProduct",
                table: "TypeProduct");

            migrationBuilder.RenameTable(
                name: "TypeProduct",
                newName: "dbo.TypeProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.TypeProduct",
                table: "dbo.TypeProduct",
                column: "TypeProductID");
        }
    }
}
