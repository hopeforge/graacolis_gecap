using BackEnd.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infra.Mappings {
public class BadgeMapeamento : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.ToTable("Badge");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ImgURL);
            builder.Property(x => x.Token);
            builder.HasOne(x=> x.Usuario);
            builder.HasOne(x=> x.Desafio);
        }
    }
}