using BackEnd.Domain;
using BackEnd.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infra.Context
{
    public class GRAACCDbContext : DbContext
    {
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Desafio> Desafios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Ganhador> Ganhadores { get; set; }
        public DbSet<Premiacao> Premiacoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        // n para n
        public DbSet<DesafioUsuario> DesafioUsuario { get; set; }

        public GRAACCDbContext(DbContextOptions<GRAACCDbContext> options) :
                base(options)
        {
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // models
            modelBuilder.ApplyConfiguration(new BadgeMapeamento());
            modelBuilder.ApplyConfiguration(new DesafioMapeamento());
            modelBuilder.ApplyConfiguration(new EmpresaMapeamento());
            modelBuilder.ApplyConfiguration(new GanhadorMapeamento());
            modelBuilder.ApplyConfiguration(new PremiacaoMapeamento());
            modelBuilder.ApplyConfiguration(new UsuarioMapeamento());
     
            // models n para n
            modelBuilder.ApplyConfiguration(new DesafioUsuarioMapeamento());

            base.OnModelCreating(modelBuilder);
        }

    }

}