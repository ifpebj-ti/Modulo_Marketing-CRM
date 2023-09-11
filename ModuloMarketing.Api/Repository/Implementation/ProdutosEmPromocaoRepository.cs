using ModuloMarketing.Api.Domain;
using ModuloMarketing.Api.Repository.Interfaces;

namespace ModuloMarketing.Api.Repository.Implementation
{
    public class ProdutosEmPromocaoRepository : IProdutosEmPromocaoRepository
    {
        private readonly DbContexto _contexto;

        public ProdutosEmPromocaoRepository(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public List<ProdutosEmPromocao> GetTodosOsProdutosEmPromocao()
        {
            return _contexto.ProdutosEmPromocao.ToList();
        }
    }
}
