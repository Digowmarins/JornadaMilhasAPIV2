using System.ComponentModel.DataAnnotations;

namespace JORNADAMILHASAPI.Data.Dtos
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Campo ID é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo PicUrl é obrigatório")]
        public string PicUrl { get; set; }
        [Required(ErrorMessage = "Campo Depoimento é obrigatório")]
        public string Depoimento { get; set; }
        [Required(ErrorMessage = "Campo Name é obrigatório")]
        public string Name { get; set; }
    }
}
