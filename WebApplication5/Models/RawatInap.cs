using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Rawat_Inap
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NIK { get; set; }
        public string Kamar { get; set; }
        public string Dokter { get; set; }
        public DateTime Tanggal { get; set; } = DateTime.Now;
    }
}