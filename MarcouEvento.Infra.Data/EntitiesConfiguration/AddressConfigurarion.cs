﻿using MarcouEvento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcouEvento.Infra.Data.EntitiesConfiguration;

class AddressConfigurarion : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x=> x.Neighborhood).HasMaxLength(1000);
        builder.Property(x=> x.City).HasMaxLength(1000).IsRequired();
        builder.Property(x=> x.State).HasMaxLength(2).IsRequired();
        builder.Property(x=> x.ZipCode).HasMaxLength(8).IsRequired();        
    }
}
