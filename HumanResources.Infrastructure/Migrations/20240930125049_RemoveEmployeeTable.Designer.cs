﻿// <auto-generated />
using System;
using HumanResources.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HumanResources.Infrastructure.Migrations
{
    [DbContext(typeof(HumanResourcesDbContext))]
    [Migration("20240930125049_RemoveEmployeeTable")]
    partial class RemoveEmployeeTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DepartmentWorker", b =>
                {
                    b.Property<Guid>("DepartmentsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DepartmentsId", "WorkersId");

                    b.HasIndex("WorkersId");

                    b.ToTable("DepartmentWorker");
                });

            modelBuilder.Entity("HumanResources.Core.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("HumanResources.Core.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HumanResources.Core.Models.Profession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Professions");
                });

            modelBuilder.Entity("HumanResources.Core.Models.Speciality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("HumanResources.Core.Models.Vacancy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ComapnyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid>("ProfessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReceiptDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ComapnyId");

                    b.HasIndex("ProfessionId");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("HumanResources.Core.Models.Worker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasMaxLength(255)
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SpecialityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("DepartmentWorker", b =>
                {
                    b.HasOne("HumanResources.Core.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HumanResources.Core.Models.Worker", null)
                        .WithMany()
                        .HasForeignKey("WorkersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HumanResources.Core.Models.Department", b =>
                {
                    b.HasOne("HumanResources.Core.Models.Company", "Company")
                        .WithMany("Departments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("HumanResources.Core.Models.Vacancy", b =>
                {
                    b.HasOne("HumanResources.Core.Models.Company", "Company")
                        .WithMany("Vacancies")
                        .HasForeignKey("ComapnyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HumanResources.Core.Models.Profession", "Profession")
                        .WithMany("Vacancies")
                        .HasForeignKey("ProfessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Profession");
                });

            modelBuilder.Entity("HumanResources.Core.Models.Worker", b =>
                {
                    b.HasOne("HumanResources.Core.Models.Speciality", "Speciality")
                        .WithMany("Workers")
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Speciality");
                });

            modelBuilder.Entity("HumanResources.Core.Models.Company", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Vacancies");
                });

            modelBuilder.Entity("HumanResources.Core.Models.Profession", b =>
                {
                    b.Navigation("Vacancies");
                });

            modelBuilder.Entity("HumanResources.Core.Models.Speciality", b =>
                {
                    b.Navigation("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}
