using Microsoft.EntityFrameworkCore;
using ModuloMarketing.Api.Domain;

namespace ModuloMarketing.Api.Repository
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options):base(options) 
        { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Habilitar o Lazy Loading
            optionsBuilder.UseLazyLoadingProxies();
        }


        public DbSet<Produto> Produto { get; set; }
        public DbSet<ProdutosEmPromocao> ProdutosEmPromocao { get; set; }
        public DbSet<Campanha> Marketing { get; set; }
        public DbSet<ResultadoCampanha> ResultadoMarketing { get; set; }
        public DbSet<Canal> Canal { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<HistoricoCampanhas> HistoricoCampanhas { get; set; }

    }
}
