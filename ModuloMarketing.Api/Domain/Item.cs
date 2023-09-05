using System.ComponentModel.DataAnnotations;

public class Item
{

	[Required]
	public int Id { get; set; }

	public Venda Venda { get; set; }

	[Required]
	public int VendaId { get; set; }

	public Produto Produto { get; set; }

	[Required]
	public int ProdutoId { get; set; }

	[Required]
	public int Quantidade { get; set; }

	[Required]
	public double PrecoUnitario { get; set; }

}