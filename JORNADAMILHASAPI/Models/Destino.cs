using System.ComponentModel.DataAnnotations;

namespace JORNADAMILHASAPI.Models
{
    public class Destino
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PicUrl { get; set; }
        [Required]
        public string PicUrl2 { get; set; }
        [Required]
        [MaxLength(160)]
        public string Meta { get; set; }
        public string? Description { get; set; }
    }
}
