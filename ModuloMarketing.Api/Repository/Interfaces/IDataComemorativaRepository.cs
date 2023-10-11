using ModuloMarketing.Api.Domain;

namespace ModuloMarketing.Api.Repository.Interfaces
{
    public interface IDataComemorativaRepository
    {
        Task<List<DataComemorativa>> GetDatasComemorativasDoMes();
    }
}
