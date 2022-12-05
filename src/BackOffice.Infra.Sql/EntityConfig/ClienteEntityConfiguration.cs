using BackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace BackOffice.Infra.Sql.EntityConfig;

public class ClienteEntityConfiguration
{
    public ClienteEntityConfiguration(EntityTypeBuilder<ClienteModel> builder)
    {
        builder
            .Property(b => b.Nome)
            .HasMaxLength(60)
            .IsRequired();

        builder
            .Property(b => b.Cpf)
            .HasMaxLength(18)
            .IsRequired();

        builder
            .Property(b => b.Email)
            .HasMaxLength(80)
            .IsRequired();


        builder
            .Property(b => b.Celular)
            .HasMaxLength(15)
            .IsRequired();

    }

}
