using System.ComponentModel.DataAnnotations;

namespace ModuloMarketing.Api.Domain
{
    public class Canal
    {
        [Key]
        public int Id_Canal { get; set; }

        [Required]
        public string Nome_Canal { get; set; }
    }
}
