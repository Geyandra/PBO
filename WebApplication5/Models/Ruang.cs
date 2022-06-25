using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Ruang
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nama { get; set; }
        public string Jenis { get; set; }
        public string Kelas { get; set; }
        public string Kapasitas { get; set; }
    }
}