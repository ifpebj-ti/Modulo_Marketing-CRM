using Microsoft.EntityFrameworkCore;
using ModuloMarketing.Api.Domain;
using ModuloMarketing.Api.Repository.Interfaces;

namespace ModuloMarketing.Api.Repository.Implementation
{
    public class DataComemorativaRepository : IDataComemorativaRepository
    {
        private readonly DbContexto _contexto;

        public DataComemorativaRepository(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<DataComemorativa>> GetDatasComemorativasDoMes()
        {
            try
            {
                var mesVigente = DateTime.Today.Month;
                List<DataComemorativa> datasComemorativas = await _contexto.DataComemorativa.Where(x=> x.Mes == mesVigente).ToListAsync(); 
                return datasComemorativas;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
