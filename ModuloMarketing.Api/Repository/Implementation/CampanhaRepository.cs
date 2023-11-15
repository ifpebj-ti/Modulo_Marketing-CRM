using ModuloMarketing.Api.Repository.Interfaces;
using ModuloMarketing.Api.Repository;
using Microsoft.EntityFrameworkCore;
using ModuloMarketing.Api.Domain;
using ModuloMarketing.Api.DTOs;

namespace ModuloMarketing.Api.Repository.Implementation
{
    public class CampanhaRepository : ICampanhaRepository
    {

        private readonly DbContexto Contexto;

        public CampanhaRepository(DbContexto contexto)
        {
            Contexto = contexto;
        }

        public async Task<List<Campanha>> GetTodasASCampanhas(int pageNumber, int itemNumber)
        {
            int skip = (pageNumber - 1) * itemNumber;
            int take = itemNumber;

            List<Campanha> campanhas = await this.Contexto.Campanha
                .OrderBy(Data_Inicio => Data_Inicio.Data_Inicio)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return campanhas;
        }

        public async Task<List<Campanha>> GetCampanhasAtivas(int pageNumber, int itemNumber)
        {
            int skip = (pageNumber - 1) * itemNumber;
            int take = itemNumber;

            List<Campanha> campanhasAtivas = await this.Contexto.Campanha
                .OrderBy(Data_Inicio => Data_Inicio.Data_Inicio)
                .Where(campanha => campanha.Status == true)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return campanhasAtivas;
        }

        public async Task<List<Campanha>> GetCampanhasRecorrentes(int pageNumber, int itemNumber)
        {
            int skip = (pageNumber - 1) * itemNumber;
            int take = itemNumber;

            List<Campanha> campanhasAtivas = await this.Contexto.Campanha
                .OrderBy(Data_Inicio => Data_Inicio.Data_Inicio)
                .Where(campanha => campanha.Recorrente == true)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return campanhasAtivas;
        }

        public async Task<int> GetQuantidadeCampanhasAtivas()
        {
            int qntdCampanhas = await this.Contexto.Campanha.Where(campanha => campanha.Status == true).CountAsync();

            return qntdCampanhas;
        }

        public async Task<Campanha> GetCampanhaPorId(int id)
        {
            Campanha campanha = await this.Contexto.Campanha.FirstOrDefaultAsync(m => m.Id_Campanha == id);
            return campanha;
        }


        public async Task<Campanha> SalvarCampanha(CampanhaRequest request)
        {
            var campanha = new Campanha
            {
                Nome_Campanha = request.Nome_Campanha,
                Email_Criador = request.Email_Criador,
                Nome_Criador = request.Nome_Criador,
                Descricao = request.Descricao,
                Data_Inicio = request.Data_Inicio,
                Status = true,
                Data_Termino = request.Data_Termino,
                Data_Criacao = request.Data_Criacao,
                Possui_Disparo_Mensagem = false,
                mensagem = request.Mensagem,
                Alcance = 0,
                Observacao = request.Observacao,
                Valor_Meta = request.Valor_Meta,
                Frequencia = (Enuns.FrequenciaRecorrencia)request.Frequencia,
                Dia_Da_Semana_Da_Recorrencia = request.Dia_Da_Semana_Da_Recorrencia,
                Dia_Do_Mes_Da_Recorrencia = request.Dia_Do_Mes_Da_Recorrencia,
                Frequencia_de_Repeticao = request.Frequencia_de_Repeticao,
            };

            await Contexto.Campanha.AddAsync(campanha);
            await Contexto.SaveChangesAsync();
            return campanha;
        }

        public async Task DesativarCampanha(int campanhaId)
        {
            var campanha = await Contexto.Campanha.FirstOrDefaultAsync(c => c.Id_Campanha == campanhaId);

            if (campanha != null)
            {

                campanha.Status = false;
                await Contexto.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Campanha com ID {campanhaId} não encontrada.");
            }
        }

        
    }
}
