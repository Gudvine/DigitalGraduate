using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalGraduate.Data.Migrations.ApplicationDbContextMigrations
{
    /// <inheritdoc />
    public partial class ChangedCertificateApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CertificateApplications_GraduateStudents_StudentId",
                table: "CertificateApplications");

            migrationBuilder.DropIndex(
                name: "IX_CertificateApplications_StudentId",
                table: "CertificateApplications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CertificateApplications_StudentId",
                table: "CertificateApplications",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CertificateApplications_GraduateStudents_StudentId",
                table: "CertificateApplications",
                column: "StudentId",
                principalTable: "GraduateStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
