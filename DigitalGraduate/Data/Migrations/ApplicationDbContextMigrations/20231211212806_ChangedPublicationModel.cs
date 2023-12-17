using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalGraduate.Data.Migrations.ApplicationDbContextMigrations
{
    /// <inheritdoc />
    public partial class ChangedPublicationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Publications",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Adviser",
                table: "Publications",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adviser",
                table: "Publications");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Publications",
                newName: "Name");
        }
    }
}
