using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Pasien> Pasiens { get; set; }
        public DbSet<Dokter> Dokters { get; set; }
        public DbSet<Pembayaran> Pembayarans { get; set; }
        public DbSet<Rawat_Inap> Rawat_Inaps { get; set; }
        public DbSet<Ruang> Ruangs { get; set; }
    }
}
