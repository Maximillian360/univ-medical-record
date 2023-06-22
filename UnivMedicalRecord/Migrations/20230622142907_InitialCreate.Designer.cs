﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityMedicalRecord.Data;

#nullable disable

namespace UnivMedicalRecord.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230622142907_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UnivMedicalRecord.Models.Comms.MessagePost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<byte[]>("message")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MessagePosts");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.CBC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Activity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Basophil")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Blast")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("BleedingTime")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BloodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ClottingTime")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Control")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateRetrieved")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Eosinophil")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Esr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Hb")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Hct")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Inr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Lymphocyte")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Malaria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Metamyelocyte")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Monocyte")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Myelocyte")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PatientRatio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Plt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Promyelocyte")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Rbc")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RedCellMorphology")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Reticulocyte")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Segmenter")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Stab")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Test")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Wbc")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("labResultId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("labResultId");

                    b.ToTable("BloodCounts");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.Cholesterol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateRetrieved")
                        .HasColumnType("datetime2");

                    b.Property<string>("OtherRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TradBua")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TradBun")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TradCholesterol")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TradCreatinine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TradDhdl")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TradFbs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TradLdl")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TradTriglyceride")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("labResultId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("labResultId");

                    b.ToTable("Cholesterols");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.CholesterolSI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Amylase")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Chloride")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Ckmb")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateRetrieved")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("IonizedCalcium")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Potassium")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Sgot")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Sgpt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SiBua")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SiBun")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SiCholesterol")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SiCreatinine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SiDhdl")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SiFbs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SiLdl")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SiTriglyceride")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Sodium")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("labResultId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("labResultId");

                    b.ToTable("CholesterolSis");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.FamilyInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FatherAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherOccupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianOccupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianRelation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherOccupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("FamilyInfos");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.Fecalysis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Consistency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateRetrieved")
                        .HasColumnType("datetime2");

                    b.Property<string>("FurtherRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MicroOtherFindings")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MicroRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OccultBlood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherFindings")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("StoolPusCells")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("StoolRbc")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StoolRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("labResultId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("labResultId");

                    b.ToTable("Fecalyses");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.LabResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("CbcEncoded")
                        .HasColumnType("bit");

                    b.Property<string>("CbcRes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CholesEncoded")
                        .HasColumnType("bit");

                    b.Property<string>("CholesterolRes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FecalEncoded")
                        .HasColumnType("bit");

                    b.Property<string>("FecalysisRes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UrinalEncoded")
                        .HasColumnType("bit");

                    b.Property<string>("UrinalysisRes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LabResults");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.Medical", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Allergy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Illness")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Medicals");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.Personal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Insurance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalDoctor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Personals");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.Urinalysis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Albumin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AmorphousPhosphates")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AmorphousUrates")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Appearance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bacteria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Casts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Crystals")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateRetrieved")
                        .HasColumnType("datetime2");

                    b.Property<string>("EpithelialCells")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MucusThread")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OthersMicroAnalysis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OthersUrinalysis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Ph")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Pregnancy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PusCells")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rbc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Specgrav")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sugar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YeastCells")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("labResultId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("labResultId");

                    b.ToTable("Urinalyses");
                });

            modelBuilder.Entity("UniversityMedicalRecord.Models.Admin.AdminRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("AdminRoles");
                });

            modelBuilder.Entity("UniversityMedicalRecord.Models.Employee.EmployeeRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeePosition")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeRoles");
                });

            modelBuilder.Entity("UniversityMedicalRecord.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsRequested")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Middlename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Comms.MessagePost", b =>
                {
                    b.HasOne("UniversityMedicalRecord.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.CBC", b =>
                {
                    b.HasOne("UnivMedicalRecord.Models.Record.LabResult", "labResult")
                        .WithMany()
                        .HasForeignKey("labResultId");

                    b.Navigation("labResult");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.Cholesterol", b =>
                {
                    b.HasOne("UnivMedicalRecord.Models.Record.LabResult", "labResult")
                        .WithMany()
                        .HasForeignKey("labResultId");

                    b.Navigation("labResult");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.CholesterolSI", b =>
                {
                    b.HasOne("UnivMedicalRecord.Models.Record.LabResult", "labResult")
                        .WithMany()
                        .HasForeignKey("labResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("labResult");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.FamilyInfo", b =>
                {
                    b.HasOne("UniversityMedicalRecord.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.Fecalysis", b =>
                {
                    b.HasOne("UnivMedicalRecord.Models.Record.LabResult", "labResult")
                        .WithMany()
                        .HasForeignKey("labResultId");

                    b.Navigation("labResult");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.LabResult", b =>
                {
                    b.HasOne("UniversityMedicalRecord.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.Medical", b =>
                {
                    b.HasOne("UniversityMedicalRecord.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.Personal", b =>
                {
                    b.HasOne("UniversityMedicalRecord.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("UnivMedicalRecord.Models.Record.Urinalysis", b =>
                {
                    b.HasOne("UnivMedicalRecord.Models.Record.LabResult", "labResult")
                        .WithMany()
                        .HasForeignKey("labResultId");

                    b.Navigation("labResult");
                });

            modelBuilder.Entity("UniversityMedicalRecord.Models.Admin.AdminRole", b =>
                {
                    b.HasOne("UniversityMedicalRecord.Models.User", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("UniversityMedicalRecord.Models.Employee.EmployeeRole", b =>
                {
                    b.HasOne("UniversityMedicalRecord.Models.User", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
