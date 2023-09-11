using System.ComponentModel.DataAnnotations;

public class Venda
{

	[Required]
	public int ID_Venda { get; set; }

	[Required]
	public DateTime DataHoraVenda { get; set; }

	public Cliente Cliente { get; set; }

	[Required]
	public int ClienteId { get; set; }

	[Required]
	public double TotalVenda { get; set; }

}