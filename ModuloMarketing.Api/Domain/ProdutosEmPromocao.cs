using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloMarketing.Api.Domain
{
    public class ProdutosEmPromocao
    {
        [Key]
        public int ID_Promocao { get; set; }
        public int ID_Produto { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal Desconto { get; set; }
        [ForeignKey("ID_Produto")]
        public virtual Produto Produto { get; set; }
    }
}
