using ModuloMarketing.Api.Domain;
using ModuloMarketing.Api.DTOs;

namespace ModuloMarketing.Api.Repository.Interfaces
{
    public interface ICampanhaRepository 
    {
        Task<List<Campanha>> GetTodasASCampanhas(int pageNumber, int itemNumber);
        Task<List<Campanha>> GetCampanhasAtivas(int pageNumber, int itemNumber);
        Task<int> GetQuantidadeCampanhasAtivas();
        Task<Campanha> GetCampanhaPorId(int id);
        Task<Campanha> SalvarCampanha(CampanhaRequest request);
        Task DesativarCampanha(int campanhaId);
        Task AtivarCampanha(int campanhaId);
        Task<List<Campanha>> GetCampanhasRecorrentes(int pageNumber, int itemNumber);
    }
}
