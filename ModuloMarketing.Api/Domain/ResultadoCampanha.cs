using System.ComponentModel.DataAnnotations;

namespace ModuloMarketing.Api.Domain;
public class ResultadoCampanha
{

    [Required]
    [Key]
    public int Id_Resultado { get; set; }

    [Required]
    public int Id_Campanha { get; set; }

    [Required]
    public int Alcance { get; set; }

    public string Observacao { get; set; }

}