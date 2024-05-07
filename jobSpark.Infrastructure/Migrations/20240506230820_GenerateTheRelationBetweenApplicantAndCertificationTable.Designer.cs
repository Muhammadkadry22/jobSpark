﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using jobSpark.Infrastructure.Context;

#nullable disable

namespace jobSpark.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240506230820_GenerateTheRelationBetweenApplicantAndCertificationTable")]
    partial class GenerateTheRelationBetweenApplicantAndCertificationTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("jobSpark.Domain.Entities.Achievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CertificationId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkingHistoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CertificationId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("WorkingHistoryId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("jobSpark.Domain.Entities.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brief")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("GraduationYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("jobSpark.Domain.Entities.Certification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApplicantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CompletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Institution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("Certifications");
                });

            modelBuilder.Entity("jobSpark.Domain.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApplicantId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skills")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("jobSpark.Domain.Entities.WorkingHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WorkingHistories");
                });

            modelBuilder.Entity("jobSpark.Domain.Entities.Achievement", b =>
                {
                    b.HasOne("jobSpark.Domain.Entities.Certification", "Certifications")
                        .WithMany("Achievements")
                        .HasForeignKey("CertificationId");

                    b.HasOne("jobSpark.Domain.Entities.Project", "Project")
                        .WithMany("Achievements")
                        .HasForeignKey("ProjectId");

                    b.HasOne("jobSpark.Domain.Entities.WorkingHistory", "WorkingHistories")
                        .WithMany("Achievements")
                        .HasForeignKey("WorkingHistoryId");

                    b.Navigation("Certifications");

                    b.Navigation("Project");

                    b.Navigation("WorkingHistories");
                });

            modelBuilder.Entity("jobSpark.Domain.Entities.Certification", b =>
                {
                    b.HasOne("jobSpark.Domain.Entities.Applicant", "Applicant")
                        .WithMany("Certifications")
                        .HasForeignKey("ApplicantId");

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("jobSpark.Domain.Entities.Project", b =>
                {
                    b.HasOne("jobSpark.Domain.Entities.Applicant", "Applicant")
                        .WithMany("Projects")
                        .HasForeignKey("ApplicantId");

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("jobSpark.Domain.Entities.Applicant", b =>
                {
                    b.Navigation("Certifications");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("jobSpark.Domain.Entities.Certification", b =>
                {
                    b.Navigation("Achievements");
                });

            modelBuilder.Entity("jobSpark.Domain.Entities.Project", b =>
                {
                    b.Navigation("Achievements");
                });

            modelBuilder.Entity("jobSpark.Domain.Entities.WorkingHistory", b =>
                {
                    b.Navigation("Achievements");
                });
#pragma warning restore 612, 618
        }
    }
}
