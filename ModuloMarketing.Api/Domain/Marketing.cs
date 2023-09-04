public class Marketing
{

	public int Id { get; set; }
	public string Nome { get; set; }
	public string Descricao { get; set; }
	public DateTime DataInicio { get; set; }
	public DateTime DataTermino { get; set; }
	public string Canais { get; set; }
	public List<Cliente> Clientes { get; } = new();

}