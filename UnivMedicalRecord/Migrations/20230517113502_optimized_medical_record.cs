using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnivMedicalRecord.Migrations
{
    /// <inheritdoc />
    public partial class optimized_medical_record : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergies_GeneralRecords_GeneralRecordId",
                table: "Allergies");

            migrationBuilder.DropForeignKey(
                name: "FK_Illnesses_GeneralRecords_GeneralRecordId",
                table: "Illnesses");

            migrationBuilder.DropTable(
                name: "GeneralRecords");

            migrationBuilder.RenameColumn(
                name: "GeneralRecordId",
                table: "Illnesses",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Illnesses_GeneralRecordId",
                table: "Illnesses",
                newName: "IX_Illnesses_UserId");

            migrationBuilder.RenameColumn(
                name: "GeneralRecordId",
                table: "Allergies",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Allergies_GeneralRecordId",
                table: "Allergies",
                newName: "IX_Allergies_UserId");

            migrationBuilder.CreateTable(
                name: "FamilyInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    GurdianRelation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personals",
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
                    Insurance = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyInfos_UserId",
                table: "FamilyInfos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Personals_UserId",
                table: "Personals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergies_Users_UserId",
                table: "Allergies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Illnesses_Users_UserId",
                table: "Illnesses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergies_Users_UserId",
                table: "Allergies");

            migrationBuilder.DropForeignKey(
                name: "FK_Illnesses_Users_UserId",
                table: "Illnesses");

            migrationBuilder.DropTable(
                name: "FamilyInfos");

            migrationBuilder.DropTable(
                name: "Personals");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Illnesses",
                newName: "GeneralRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_Illnesses_UserId",
                table: "Illnesses",
                newName: "IX_Illnesses_GeneralRecordId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Allergies",
                newName: "GeneralRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_Allergies_UserId",
                table: "Allergies",
                newName: "IX_Allergies_GeneralRecordId");

            migrationBuilder.CreateTable(
                name: "GeneralRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FatherAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GurdianAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GurdianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GurdianOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GurdianRelation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GurdianStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalDoctor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_GeneralRecords_UserId",
                table: "GeneralRecords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergies_GeneralRecords_GeneralRecordId",
                table: "Allergies",
                column: "GeneralRecordId",
                principalTable: "GeneralRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Illnesses_GeneralRecords_GeneralRecordId",
                table: "Illnesses",
                column: "GeneralRecordId",
                principalTable: "GeneralRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
