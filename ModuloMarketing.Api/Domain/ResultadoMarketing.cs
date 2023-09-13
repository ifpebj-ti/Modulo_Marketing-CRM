using System.ComponentModel.DataAnnotations;

public class ResultadoMarketing
{

    [Required]
    [Key]
    public int Id_Resultado { get; set; }

    [Required]
    public int Id_Marketing { get; set; }

    [Required]
    public int Alcance { get; set; }

    public string Observacao { get; set; }

}