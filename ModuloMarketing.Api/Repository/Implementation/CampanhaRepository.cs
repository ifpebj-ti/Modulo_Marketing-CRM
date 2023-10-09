﻿using ModuloMarketing.Api.Repository.Interfaces;
using ModuloMarketing.Api.Repository;
using Microsoft.EntityFrameworkCore;

namespace ModuloMarketing.Api.Repository.Implementation
{
    public class CampanhaRepository: ICampanhaRepository
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
                Descricao = request.Descricao,
                Data_Inicio = request.Data_Inicio,
                Status = true,
                Data_Termino = request.Data_Termino,
                Possui_Disparo_Mensagem = false,
                mensagem = request.Mensagem,
                Alcance = 0,
                Observacao = request.Observacao
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
