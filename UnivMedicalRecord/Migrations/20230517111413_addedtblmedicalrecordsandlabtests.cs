using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnivMedicalRecord.Migrations
{
    /// <inheritdoc />
    public partial class addedtblmedicalrecordsandlabtests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodCounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateRetrieved = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Wbc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Rbc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Hb = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Hct = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Plt = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Mcv = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Mch = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Mchc = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodCounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodCounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalDoctor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Insurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GurdianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GurdianStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GurdianAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GurdianOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GurdianRelation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSigned = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MicroUrinalysis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RBC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EpithelialCells = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bacteria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MicroUrinalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MicroUrinalysis_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Urinalyses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateRetrieved = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Appearance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Glucose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bilirubin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ketone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specgrav = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Blood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ph = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Protein = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Urobilinogen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nitrite = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Leukesterase = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urinalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urinalyses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralRecordId = table.Column<int>(type: "int", nullable: false),
                    AllergyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergies_GeneralRecords_GeneralRecordId",
                        column: x => x.GeneralRecordId,
                        principalTable: "GeneralRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Illnesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralRecordId = table.Column<int>(type: "int", nullable: false),
                    IllnessName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illnesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Illnesses_GeneralRecords_GeneralRecordId",
                        column: x => x.GeneralRecordId,
                        principalTable: "GeneralRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_GeneralRecordId",
                table: "Allergies",
                column: "GeneralRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodCounts_UserId",
                table: "BloodCounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralRecords_UserId",
                table: "GeneralRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Illnesses_GeneralRecordId",
                table: "Illnesses",
                column: "GeneralRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_MicroUrinalysis_UserId",
                table: "MicroUrinalysis",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Urinalyses_UserId",
                table: "Urinalyses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "BloodCounts");

            migrationBuilder.DropTable(
                name: "Illnesses");

            migrationBuilder.DropTable(
                name: "MicroUrinalysis");

            migrationBuilder.DropTable(
                name: "Urinalyses");

            migrationBuilder.DropTable(
                name: "GeneralRecords");
        }
    }
}
