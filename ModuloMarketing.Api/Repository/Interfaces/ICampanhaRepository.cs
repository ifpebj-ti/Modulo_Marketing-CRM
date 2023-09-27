namespace ModuloMarketing.Api.Repository.Interfaces
{
    public interface ICampanhaRepository 
    {
        Task<List<Campanha>> GetTodasASCampanhas();
        Task<Campanha> GetCampanhaPorId(int id);
        Task<Campanha> SalvarCampanha(CampanhaRequest request);
    }
}
