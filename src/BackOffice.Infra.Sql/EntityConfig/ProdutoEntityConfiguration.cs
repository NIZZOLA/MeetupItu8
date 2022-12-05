
using BackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackOffice.Infra.Sql.EntityConfig;

public class ProdutoEntityConfiguration
{
	public ProdutoEntityConfiguration(EntityTypeBuilder<ProdutoModel> builder)
    {
        builder
            .Property(b => b.Descricao)
            .HasMaxLength(60)
            .IsRequired();

    }
}
