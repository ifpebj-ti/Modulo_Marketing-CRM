using System.ComponentModel.DataAnnotations;

namespace ModuloMarketing.Api.Domain
{
    public class Categoria
    {
        [Key]
        public int Id_Categoria { get; set; }
        [Required]
        public string Nome_Categoria { get; set; }
    }
}
