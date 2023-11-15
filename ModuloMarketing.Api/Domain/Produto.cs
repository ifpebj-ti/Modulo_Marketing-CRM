using System.ComponentModel.DataAnnotations;

namespace ModuloMarketing.Api.Domain;

public class Produto
{

	[Required]
	[Key]
	public int ID_Produto { get; set; }
	
	[Required]
	[MaxLength(100)]
	public string NomeProduto { get; set; }
	
	[Required]
	[MaxLength(255)]
	public string Descricao { get; set; }
	
	[Required]
	[MaxLength(50)]
	public string Categoria { get; set; }
	
	[Required]
	public decimal PrecoVenda { get; set; }
	
	[Required]
	public int QuantidadeEstoque { get; set; }
	
	[Required]
	public DateTime DataValidade { get; set; }
	
	[Required]
	[MaxLength(100)]
	public string Fornecedor { get; set; }

}