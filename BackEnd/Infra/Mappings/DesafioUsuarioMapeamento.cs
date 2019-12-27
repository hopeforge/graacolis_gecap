using BackEnd.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infra.Mappings {
public class DesafioUsuarioMapeamento : IEntityTypeConfiguration<DesafioUsuario>
    {
        public void Configure(EntityTypeBuilder<DesafioUsuario> builder)
        {
            builder.ToTable("DesafioUsuario");
            builder.HasKey(x => new {x.DesafioId, x.UsuarioId});
            builder.HasOne(x=> x.Usuario).WithMany(x=> x.ListaDesafio).HasForeignKey(x=> x.UsuarioId);
            builder.HasOne(x=> x.Desafio).WithMany(x=> x.ListaParticipantes).HasForeignKey(x=> x.DesafioId);
        }
    }
}