using ModuloMarketing.Api.Domain;

namespace ModuloMarketing.Api.Repository.Interfaces
{
    public interface IProdutosEmPromocaoRepository
    {
        List<ProdutosEmPromocao> GetTodosOsProdutosEmPromocao();
    }
}
