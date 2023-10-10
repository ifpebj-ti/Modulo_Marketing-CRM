using System.ComponentModel.DataAnnotations;

namespace ModuloMarketing.Api.Domain
{
    public class DataComemorativa
    {
        [Key]
        public int Id_Comemorativa { get; set; }
        [Required]
        public string Nome_Data { get; set; }
        [Required]
        public int Dia { get; set; }
        [Required]
        public int Mes { get; set; }

    }
}
