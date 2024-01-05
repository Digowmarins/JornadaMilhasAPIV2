using System.ComponentModel.DataAnnotations;

namespace JORNADAMILHASAPI.Data.Dtos
{
    public class UpdateDestinoDto
    {
        [Required(ErrorMessage = "Campo ID é obrigatório")]
        public int Id { get; set; }     
        public string Name { get; set; }       
        public string PicUrl { get; set; }
        public string PicUrl2 { get; set; }
        public string Meta { get; set; }
        public string? Description { get; set; }
    }
}
