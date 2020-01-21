﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesWebMVC.Data;

namespace SalesWebMVC.Migrations
{
    [DbContext(typeof(SalesWebMVCContext))]
    [Migration("20200120165052_ATT")]
    partial class ATT
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SalesWebMVC.Models.Departamants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Departamants");
                });

            modelBuilder.Entity("SalesWebMVC.Models.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("BaseSalary")
                        .HasColumnType("double");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DepartamantsId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("DepartamantsId");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("SalesWebMVC.Models.SellerReacts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("sellersId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("sellersId");

                    b.ToTable("SellerRecord");
                });

            modelBuilder.Entity("SalesWebMVC.Models.Seller", b =>
                {
                    b.HasOne("SalesWebMVC.Models.Departamants", "dep")
                        .WithMany("Sellers")
                        .HasForeignKey("DepartamantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SalesWebMVC.Models.SellerReacts", b =>
                {
                    b.HasOne("SalesWebMVC.Models.Seller", "sellers")
                        .WithMany("Sales")
                        .HasForeignKey("sellersId");
                });
#pragma warning restore 612, 618
        }
    }
}
