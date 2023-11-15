using ModuloMarketing.Api.Domain;
using ModuloMarketing.Api.Enuns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloMarketing.Api.Domain;

public class Campanha
{

    [Required]
    [Key]
    public int Id_Campanha { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nome_Campanha { get; set; }

    [MaxLength(60)]
    public string Nome_Criador { get; set; }

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
    public DateTime Data_Criacao { get; set; }

    [Required]
    public bool Possui_Disparo_Mensagem { get; set; }

    public string mensagem { get; set; }

    [Required]
    public int Alcance { get; set; }

    public string Observacao { get; set; }

    public double Valor_Meta { get; set; }

    public bool Recorrente { get; set; }

    public FrequenciaRecorrencia Frequencia { get; set; }

    public int Dia_Da_Semana_Da_Recorrencia { get; set; }

    public int Dia_Do_Mes_Da_Recorrencia { get; set; }

    public int Frequencia_de_Repeticao { get; set; }

    //public List<ProdutosEmPromocao> Produtos_Em_Promo��o { get; set; }
    //public List<Filiais> Filiais_Da_Campanha { get; set; }
    //public List<Canal> Canais_De_Reproducao { get; set; }

}