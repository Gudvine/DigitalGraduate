using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalGraduate.Data.Migrations.ApplicationDbContextMigrations
{
    /// <inheritdoc />
    public partial class ChangedPublicationModelAddPublicationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicationType",
                table: "Publications",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicationType",
                table: "Publications");
        }
    }
}
