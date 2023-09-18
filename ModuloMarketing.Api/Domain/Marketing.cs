using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Marketing
{

	[Required]
	[Key]
	public int Id_Marketing { get; set; }

	[Required]
	public int Id_Resultado { get; set; }
	
	[Required]
	[MaxLength(50)]
	public string Nome_Marketing { get; set; }

	[Required]
	[MaxLength(50)]
	public string Email_Criador { get; set; }
	
	[Required]
	[MaxLength(255)]
	public string Descricao { get; set; }
	
	[Required]
	public DateTime DataInicio { get; set; }

	[Required]
	public bool Status { get; set; } = false;
	
	[Required]
	public DateTime DataTermino { get; set; }

	[ForeignKey("Id_Resuldado")]
	public virtual ResultadoMarketing ResultadoMarketing { get; set; }

	public string Observacao { get; set; }

}