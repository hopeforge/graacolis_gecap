

using BackEnd.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infra.Mappings {
public class PremiacaoMapeamento : IEntityTypeConfiguration<Premiacao>
    {
        public void Configure(EntityTypeBuilder<Premiacao> builder)
        {
            builder.ToTable("Premiacao");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Tipo);
            builder.Property(x => x.QuantidadePremiados);
            // builder.HasOne(x=> x.Desafio).WithOne(x=> x.Premiacao);
            builder.HasMany(x=> x.ListaGanhadores).WithOne(x=> x.Premiacao);
        }
    }
}