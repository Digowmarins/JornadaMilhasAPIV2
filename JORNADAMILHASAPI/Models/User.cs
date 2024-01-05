using System.ComponentModel.DataAnnotations;

namespace JORNADAMILHASAPI.Models
{
    public class User
    {       
        [Key] public int Id { get; set; }        
        [Required] public string PicUrl { get; set; }       
        [Required] public string Depoimento { get; set;}      
        [Required] public string Name { get; set; }

    }
}
