using ModuloMarketing.Api.Domain;

namespace ModuloMarketing.Api.Repository.Interfaces 
{

public interface IHistoricoCampanhasRepository
{
    
    Task<List<HistoricoCampanhas>>GetHistorico();

    Task<HistoricoCampanhas>GetHistoricoPorId(int id);

    Task<HistoricoCampanhas>SalvarHistorico(HistoricoCampanhasRequest request);

}

}