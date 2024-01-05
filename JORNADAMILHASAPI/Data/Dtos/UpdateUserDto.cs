using System.ComponentModel.DataAnnotations;

namespace JORNADAMILHASAPI.Data.Dtos
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "O campo ID é obrigatório")]
        public int Id { get; set; }
        public string PicUrl { get; set; }
        public string Depoimento { get; set; }
        public string Name { get; set; }
    }
}
