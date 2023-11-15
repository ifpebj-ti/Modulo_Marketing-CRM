using System.ComponentModel.DataAnnotations;

namespace ModuloMarketing.Api.Domain;

public class Cliente
{

	[Required]
	public int ID_Cliente { get; set; }

	[Required]
	[MaxLength(50)]
	public string Nome { get; set; }

	[MaxLength(100)]
	public string Sobrenome { get; set; }

	[Required]
	[MaxLength(100)]
	public string Endereco { get; set; }

	[Required]
	[MaxLength(15)]
	public string Telefone { get; set; }

	[Required]
	[EmailAddress]
	[MaxLength(100)]
	public string Email { get; set; }

	[Required]
	public DateTime DataNascimento { get; set; }


}