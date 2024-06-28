﻿// <auto-generated />
using System;
using LicenseApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LicenseApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240627085758_addGateModel")]
    partial class addGateModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LicenseApp.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LicenseNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SakhanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SakhanId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("LicenseApp.Models.Gate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GateCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("SakhanId")
                        .HasColumnType("int");

                    b.Property<string>("SakhanName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gates");
                });

            modelBuilder.Entity("LicenseApp.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ItemCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemCode")
                        .IsUnique();

                    b.ToTable("Items");
                });

            modelBuilder.Entity("LicenseApp.Models.LicenseItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("ItemId");

                    b.HasIndex("UnitId");

                    b.ToTable("LicenseItems");
                });

            modelBuilder.Entity("LicenseApp.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ApplicationFees")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicationNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LicenseFees")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LicenseNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SakhanId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalFees")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TransactionFees")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("LicenseApp.Models.Sakhan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GateId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("SakhanCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SakhanName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SakhanShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GateId");

                    b.HasIndex("SakhanCode")
                        .IsUnique();

                    b.ToTable("Sakhans");
                });

            modelBuilder.Entity("LicenseApp.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UnitCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UnitCode")
                        .IsUnique();

                    b.ToTable("Units");
                });

            modelBuilder.Entity("LicenseApp.Models.Application", b =>
                {
                    b.HasOne("LicenseApp.Models.Sakhan", "Sakhan")
                        .WithMany()
                        .HasForeignKey("SakhanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sakhan");
                });

            modelBuilder.Entity("LicenseApp.Models.LicenseItem", b =>
                {
                    b.HasOne("LicenseApp.Models.Application", null)
                        .WithMany("LicenseItems")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LicenseApp.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LicenseApp.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("LicenseApp.Models.Sakhan", b =>
                {
                    b.HasOne("LicenseApp.Models.Gate", null)
                        .WithMany("Sakhans")
                        .HasForeignKey("GateId");
                });

            modelBuilder.Entity("LicenseApp.Models.Application", b =>
                {
                    b.Navigation("LicenseItems");
                });

            modelBuilder.Entity("LicenseApp.Models.Gate", b =>
                {
                    b.Navigation("Sakhans");
                });
#pragma warning restore 612, 618
        }
    }
}
