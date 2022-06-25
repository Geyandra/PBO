using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    public partial class alltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_pasiens",
                table: "pasiens");

            migrationBuilder.RenameTable(
                name: "pasiens",
                newName: "Pasiens");

            migrationBuilder.AlterColumn<string>(
                name: "NIK",
                table: "Pasiens",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Alamat",
                table: "Pasiens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Keluhan",
                table: "Pasiens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nomor_Telepon",
                table: "Pasiens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pekerjaan",
                table: "Pasiens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TTL",
                table: "Pasiens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pasiens",
                table: "Pasiens",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Dokters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nomor_Telepon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pembayarans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biaya = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pembayarans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rawat_Inaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kamar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dokter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rawat_Inaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ruangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jenis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kelas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kapasitas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruangs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dokters");

            migrationBuilder.DropTable(
                name: "Pembayarans");

            migrationBuilder.DropTable(
                name: "Rawat_Inaps");

            migrationBuilder.DropTable(
                name: "Ruangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pasiens",
                table: "Pasiens");

            migrationBuilder.DropColumn(
                name: "Alamat",
                table: "Pasiens");

            migrationBuilder.DropColumn(
                name: "Keluhan",
                table: "Pasiens");

            migrationBuilder.DropColumn(
                name: "Nomor_Telepon",
                table: "Pasiens");

            migrationBuilder.DropColumn(
                name: "Pekerjaan",
                table: "Pasiens");

            migrationBuilder.DropColumn(
                name: "TTL",
                table: "Pasiens");

            migrationBuilder.RenameTable(
                name: "Pasiens",
                newName: "pasiens");

            migrationBuilder.AlterColumn<int>(
                name: "NIK",
                table: "pasiens",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pasiens",
                table: "pasiens",
                column: "Id");
        }
    }
}
