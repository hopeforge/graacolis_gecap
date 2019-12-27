using BackEnd.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infra.Mappings
{
    public class EmpresaMapeamento : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.NomeEmpresa);
            builder.Property(x => x.CNPJ);
            builder.HasMany(x => x.ListaDesafio).WithOne(y => y.Empresa);
        }
    }
}