public class Item
{

	public int Id { get; set; }
	public Venda Venda { get; set; }
	public int VendaId { get; set; }
	public Produto Produto { get; set; }
	public int ProdutoId { get; set; }
	public int Quantidade { get; set; }
	public double PrecoUnitario { get; set; }

}