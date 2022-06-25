using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Dokter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nama { get; set; }
        public string Poli { get; set; }
        public string Nomor_Telepon { get; set; }
        public string Alamat { get; set; }
    }
}