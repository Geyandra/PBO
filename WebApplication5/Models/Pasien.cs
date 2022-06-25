using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Pasien
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nama { get; set; }
        public string NIK { get; set; }
        public string Jenis_Kelamin { get; set; }
        public int Umur { get; set; }
        public string TTL { get; set; }
        public string Alamat { get; set; }
        public string Nomor_Telepon { get; set; }
        public string Pekerjaan { get; set; }
        public string Poli { get; set; }
        public string Keluhan { get; set; }
    }
}
