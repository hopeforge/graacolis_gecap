
using BackEnd.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infra.Mappings {
public class GanhadorMapeamento : IEntityTypeConfiguration<Ganhador>
    {
        public void Configure(EntityTypeBuilder<Ganhador> builder)
        {
            builder.ToTable("Ganhador");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome);
            builder.Property(x => x.LinkedinUrl);
            builder.HasOne(x=> x.Usuario);
            builder.HasOne(x=> x.Premiacao);
            builder.HasOne(x=> x.Desafio).WithMany(x=> x.ListaGanhadores);
        }
    }
}