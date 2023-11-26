using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalGraduate.Data.Migrations.ApplicationDbContextMigrations
{
    /// <inheritdoc />
    public partial class AddedEditionField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Edition",
                table: "Publications",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edition",
                table: "Publications");
        }
    }
}
