        using MarcouEvento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcouEvento.Infra.Data.EntitiesConfiguration
{
    public class PartyConfiguration : IEntityTypeConfiguration<Party>
    {
        public void Configure(EntityTypeBuilder<Party> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.DateStart).IsRequired();
            builder.Property(x => x.DateFinish).IsRequired();

            builder.HasOne(x => x.Address)
                .WithMany()
                .HasForeignKey(x => x.AddressId);

            builder.HasMany(x => x.Expenses)
                .WithOne(y => y.Party)
                .HasForeignKey(y => y.PartyId);
        }
    }
}
