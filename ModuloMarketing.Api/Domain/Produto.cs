using System.ComponentModel.DataAnnotations;

public class Produto
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
	[MaxLength(50)]
	public string Categoria { get; set; }
	
	[Required]
	public double Preco { get; set; }
	
	[Required]
	public int Quantidade { get; set; }
	
	[Required]
	public DateTime DataValidade { get; set; }
	
	[Required]
	[MaxLength(100)]
	public string Fornecedor { get; set; }

}