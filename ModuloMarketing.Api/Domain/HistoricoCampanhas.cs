using System.ComponentModel.DataAnnotations;

namespace ModuloMarketing.Api.Domain
{
    public class HistoricoCampanhas
    {
        [Key]
        public int Id_Historico_Campanha { get; set; }
        [Required]
        public int Id_Campanha { get; set; }
        [Required]
        public int Id_Resultado_Campanha { get; set; }
        [Required]
        public DateOnly Data_Inicio { get; set; }
        [Required]
        public DateOnly Data_Fim { get; set; }
        [Required]
        public string Descricao { get; set; }


    }
}
