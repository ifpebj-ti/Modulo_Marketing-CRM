using System.ComponentModel.DataAnnotations;

public class Venda
{

	[Required]
	public int Id { get; set; }

	[Required]
	public DateTime Data { get; set; }

	public Cliente Cliente { get; set; }

	[Required]
	public int ClienteId { get; set; }

	[Required]
	public double TotalVenda { get; set; }

}