using ModuloMarketing.Api.Repository.Interfaces;
using ModuloMarketing.Api.Repository;
using Microsoft.EntityFrameworkCore;
using ModuloMarketing.Api.Domain;

namespace ModuloMarketing.Api.Repository.Implementation
{
    public class HistoricoCampanhasRepository: IHistoricoCampanhasRepository
    {

        private readonly DbContexto Contexto;

        public HistoricoCampanhasRepository(DbContexto contexto)
        {
            Contexto = contexto;
        }

        public async Task<List<HistoricoCampanhas>> GetHistorico()
        {
            List<HistoricoCampanhas> Historico = await this.Contexto.HistoricoCampanhas.ToListAsync();
            return Historico;
        }

        public async Task<HistoricoCampanhas> GetHistoricoPorId(int id)
        {
            HistoricoCampanhas Historico = await this.Contexto.HistoricoCampanhas.FirstOrDefaultAsync(m => m.Id_Historico_Campanha == id);
            return Historico;
        }

        public async Task<HistoricoCampanhas> SalvarHistorico(HistoricoCampanhasRequest request)
        {
            var Historico = new HistoricoCampanhas
            {
                Descricao = request.Descricao,
                Data_Inicio = request.Data_Inicio,
                Data_Fim = request.Data_Fim,

            };
            await Contexto.HistoricoCampanhas.AddAsync(Historico);
            await Contexto.SaveChangesAsync();
            return Historico;
        }

    }
}
