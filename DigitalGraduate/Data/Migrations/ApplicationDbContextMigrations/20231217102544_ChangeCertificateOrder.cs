using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalGraduate.Data.Migrations.ApplicationDbContextMigrations
{
    /// <inheritdoc />
    public partial class ChangeCertificateOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WithOfficialSeal",
                table: "CertificateApplications",
                newName: "NeedOfficialSeal");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "CertificateApplications",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ProvideTo",
                table: "CertificateApplications",
                newName: "SpaceRequirement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CertificateApplications",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "SpaceRequirement",
                table: "CertificateApplications",
                newName: "ProvideTo");

            migrationBuilder.RenameColumn(
                name: "NeedOfficialSeal",
                table: "CertificateApplications",
                newName: "WithOfficialSeal");
        }
    }
}
