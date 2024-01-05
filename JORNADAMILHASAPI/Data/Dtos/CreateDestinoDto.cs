using System.ComponentModel.DataAnnotations;

namespace JORNADAMILHASAPI.Data.Dtos
{
    public class CreateDestinoDto
    {
        [Required(ErrorMessage = "Campo ID é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Name é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo PicUrl é obrigatório")]
        public string PicUrl { get; set; }
        [Required(ErrorMessage = "Campo PicUrl2 é obrigatório")]
        public string PicUrl2 { get; set; }
        [Required(ErrorMessage = "Campo Meta é obrigatório, o máximo de caracteres é 160")]
        public string Meta { get; set; }
        public string? Description { get; set; }
    }
}
