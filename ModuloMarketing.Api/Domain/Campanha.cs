using ModuloMarketing.Api.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Campanha
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
	public DateTime Data_Inicio { get; set; }

	[Required]
	public bool Status { get; set; } = false;
	
	[Required]
	public DateTime Data_Termino { get; set; }

	[Required]
    public bool Possui_Disparo_Mensagem { get; set; }

    public string mensagem { get; set; }

    [ForeignKey("Id_Resultado")]
    public virtual ResultadoCampanha Resultado_Campanha { get; set; }

    //public List<ProdutosEmPromocao> Produtos_Em_Promoção { get; set; }
    //public List<Filiais> Filiais_Da_Campanha { get; set; }
    //public List<Canal> Canais_De_Reproducao { get; set; }


}