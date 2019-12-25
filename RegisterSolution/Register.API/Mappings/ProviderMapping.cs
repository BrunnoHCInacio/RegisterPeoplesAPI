using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Register.API.Models;

namespace Register.API.Mappings
{
    public class ProviderMapping : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Document)
                .IsRequired()
                .HasColumnType("varchar(14)");

            //1 : 1 Fornecedor : Endereco
            builder
                .HasOne(p => p.Address)
                .WithOne(a => a.Provider);

            //1 : N Fornecedor : Produtos
            builder
                .HasMany(pr => pr.Products)
                .WithOne(p => p.Provider)
                .HasForeignKey(p => p.ProviderId);

            builder.ToTable("Providers");
        }
    }
}
