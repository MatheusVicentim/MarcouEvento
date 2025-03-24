using MarcouEvento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcouEvento.Infra.Data.EntitiesConfiguration;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FullName).HasMaxLength(300).IsRequired();
        builder.Property(x => x.Phone).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Status).HasMaxLength(1).IsRequired();

        builder.HasOne(x => x.Address)
            .WithMany()
            .HasForeignKey(x => x.AddressId)
            .IsRequired();
    }
}
