using System.ComponentModel.DataAnnotations;

public class Marketing
{

	[Required]
	public int Id { get; set; }
	
	[Required]
	[MaxLength(100)]
	public string Nome { get; set; }
	
	[Required]
	[MaxLength(255)]
	public string Descricao { get; set; }
	
	[Required]
	public DateTime DataInicio { get; set; }
	
	[Required]
	public DateTime DataTermino { get; set; }
	
	[Required]
	[MaxLength(100)]
	public string Canais { get; set; }
	
	public List<Cliente> Clientes { get; } = new();

}