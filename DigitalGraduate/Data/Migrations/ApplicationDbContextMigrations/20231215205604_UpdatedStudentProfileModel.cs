using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalGraduate.Data.Migrations.ApplicationDbContextMigrations
{
    /// <inheritdoc />
    public partial class UpdatedStudentProfileModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direction",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationForm",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationType",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupNumber",
                table: "Students",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EducationForm",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EducationType",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GroupNumber",
                table: "Students");
        }
    }
}
