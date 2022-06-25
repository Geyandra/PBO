﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication5.Data;

#nullable disable

namespace WebApplication5.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20220624212139_alltables")]
    partial class alltables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication5.Models.Dokter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nomor_Telepon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dokters");
                });

            modelBuilder.Entity("WebApplication5.Models.Pasien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Jenis_Kelamin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keluhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIK")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nomor_Telepon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pekerjaan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TTL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Umur")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pasiens");
                });

            modelBuilder.Entity("WebApplication5.Models.Pembayaran", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Biaya")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIK")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Pembayarans");
                });

            modelBuilder.Entity("WebApplication5.Models.Rawat_Inap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Dokter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kamar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIK")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Rawat_Inaps");
                });

            modelBuilder.Entity("WebApplication5.Models.Ruang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Jenis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kapasitas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kelas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ruangs");
                });
#pragma warning restore 612, 618
        }
    }
}
