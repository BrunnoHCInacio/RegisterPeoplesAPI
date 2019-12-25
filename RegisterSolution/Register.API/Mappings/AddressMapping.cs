using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Register.API.Models;

namespace Register.API.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Street).IsRequired().HasColumnType("varchar(200)");
            builder.Property(a => a.Number).IsRequired().HasColumnType("varchar(50)");
            builder.Property(a => a.District).IsRequired().HasColumnType("varchar(100)");
            builder.Property(a => a.City).IsRequired().HasColumnType("varchar(100)");
            builder.Property(a => a.State).IsRequired().HasColumnType("varchar(50)");
            builder.Property(a => a.Country).IsRequired().HasColumnType("varchar(50)");
            builder.Property(a => a.ZipCode).IsRequired().HasColumnType("varchar(8)");
            builder.ToTable("Addresses");
        }
    }
}
