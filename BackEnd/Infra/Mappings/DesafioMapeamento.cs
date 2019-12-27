using BackEnd.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infra.Mappings {
public class DesafioMapeamento : IEntityTypeConfiguration<Desafio>
    {
        public void Configure(EntityTypeBuilder<Desafio> builder)
        {
            builder.ToTable("Desafio");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeDesafio);
            builder.Property(x => x.Descricao);
            builder.Property(x => x.Etapas);
            builder.Property(x => x.DataInicio);
            builder.Property(x => x.DataFinal);
            builder.HasOne(x=> x.Premiacao).WithOne(x=> x.Desafio).HasForeignKey<Desafio>(x=> x.PremiacaoId);
            builder.HasMany(x=> x.ListaParticipantes);
            builder.HasOne(x=> x.Empresa).WithMany(x=> x.ListaDesafio).OnDelete(DeleteBehavior.Restrict);
        }
    }
}