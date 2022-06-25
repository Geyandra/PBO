using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Pembayaran
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NIK { get; set; }
        public string Biaya { get; set; }
        public DateTime Tanggal { get; set; } = DateTime.Now;
    }
}