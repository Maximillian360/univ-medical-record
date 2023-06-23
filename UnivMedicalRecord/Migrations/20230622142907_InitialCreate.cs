using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnivMedicalRecord.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRequested = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminRoles_Users_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeePosition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Users_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
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
                    GuardianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuardianStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuardianAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuardianOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuardianRelation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyInfos_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CholesterolRes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CbcRes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrinalysisRes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FecalysisRes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CholesEncoded = table.Column<bool>(type: "bit", nullable: false),
                    CbcEncoded = table.Column<bool>(type: "bit", nullable: false),
                    UrinalEncoded = table.Column<bool>(type: "bit", nullable: false),
                    FecalEncoded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabResults_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    Allergy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Illness = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicals_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessagePosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Recipient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    message = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagePosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessagePosts_Users_UserId",
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
                    userId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_Personals_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodCounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    labResultId = table.Column<int>(type: "int", nullable: true),
                    DateRetrieved = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Wbc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Rbc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Hb = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Hct = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Plt = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Blast = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Promyelocyte = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Myelocyte = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Metamyelocyte = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Stab = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Segmenter = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Lymphocyte = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Monocyte = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Eosinophil = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Basophil = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Esr = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Reticulocyte = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BleedingTime = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ClottingTime = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Malaria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedCellMorphology = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Test = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientRatio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodCounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodCounts_LabResults_labResultId",
                        column: x => x.labResultId,
                        principalTable: "LabResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cholesterols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    labResultId = table.Column<int>(type: "int", nullable: true),
                    DateRetrieved = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TradFbs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TradBun = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TradCreatinine = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TradBua = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TradCholesterol = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TradTriglyceride = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TradDhdl = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TradLdl = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cholesterols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cholesterols_LabResults_labResultId",
                        column: x => x.labResultId,
                        principalTable: "LabResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CholesterolSis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    labResultId = table.Column<int>(type: "int", nullable: false),
                    DateRetrieved = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SiFbs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SiBun = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SiCreatinine = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SiBua = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SiCholesterol = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SiTriglyceride = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SiDhdl = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SiLdl = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sgot = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sgpt = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Amylase = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Ckmb = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sodium = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Potassium = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Chloride = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IonizedCalcium = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CholesterolSis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CholesterolSis_LabResults_labResultId",
                        column: x => x.labResultId,
                        principalTable: "LabResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fecalyses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    labResultId = table.Column<int>(type: "int", nullable: true),
                    DateRetrieved = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StoolPusCells = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StoolRbc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Consistency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OccultBlood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MicroOtherFindings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MicroRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoolRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FurtherRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fecalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fecalyses_LabResults_labResultId",
                        column: x => x.labResultId,
                        principalTable: "LabResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Urinalyses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    labResultId = table.Column<int>(type: "int", nullable: true),
                    DateRetrieved = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Appearance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ph = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Specgrav = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EpithelialCells = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucusThread = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmorphousUrates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmorphousPhosphates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Albumin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sugar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pregnancy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Crystals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Casts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthersUrinalysis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PusCells = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rbc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bacteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YeastCells = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthersMicroAnalysis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urinalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urinalyses_LabResults_labResultId",
                        column: x => x.labResultId,
                        principalTable: "LabResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminRoles_AdminId",
                table: "AdminRoles",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodCounts_labResultId",
                table: "BloodCounts",
                column: "labResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Cholesterols_labResultId",
                table: "Cholesterols",
                column: "labResultId");

            migrationBuilder.CreateIndex(
                name: "IX_CholesterolSis_labResultId",
                table: "CholesterolSis",
                column: "labResultId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_EmployeeId",
                table: "EmployeeRoles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyInfos_userId",
                table: "FamilyInfos",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Fecalyses_labResultId",
                table: "Fecalyses",
                column: "labResultId");

            migrationBuilder.CreateIndex(
                name: "IX_LabResults_UserId",
                table: "LabResults",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicals_userId",
                table: "Medicals",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_MessagePosts_UserId",
                table: "MessagePosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Personals_userId",
                table: "Personals",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Urinalyses_labResultId",
                table: "Urinalyses",
                column: "labResultId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminRoles");

            migrationBuilder.DropTable(
                name: "BloodCounts");

            migrationBuilder.DropTable(
                name: "Cholesterols");

            migrationBuilder.DropTable(
                name: "CholesterolSis");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "FamilyInfos");

            migrationBuilder.DropTable(
                name: "Fecalyses");

            migrationBuilder.DropTable(
                name: "Medicals");

            migrationBuilder.DropTable(
                name: "MessagePosts");

            migrationBuilder.DropTable(
                name: "Personals");

            migrationBuilder.DropTable(
                name: "Urinalyses");

            migrationBuilder.DropTable(
                name: "LabResults");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
