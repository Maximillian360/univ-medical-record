using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnivMedicalRecord.Migrations
{
    /// <inheritdoc />
    public partial class optimized_medical_record1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Personals");
        }
    }
}
