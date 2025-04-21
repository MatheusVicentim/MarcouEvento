using MarcouEvento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcouEvento.Infra.Data.EntitiesConfiguration;

class AddressConfigurarion : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x=> x.Neighborhood).HasMaxLength(1000).IsRequired(false);
        builder.Property(x=> x.City).HasMaxLength(1000).IsRequired();
        builder.Property(x=> x.State).HasMaxLength(2).IsRequired();
        builder.Property(x=> x.Street).IsRequired(false);
        builder.Property(x=> x.Latitude).IsRequired(false);
        builder.Property(x=> x.Longitude).IsRequired(false);
        builder.Property(x=> x.UrlMaps).IsRequired(false);
        builder.Property(x=> x.Complement).IsRequired(false);
        builder.Property(x=> x.Type).HasConversion<int>().IsRequired();


        builder.HasData(new Address(1,"R. Carlos Gomes", 574, "Centro", "São João das Duas Pontes", "UF", "15640047","","","Casa", "", Address.EType.Residential));
    }
}
