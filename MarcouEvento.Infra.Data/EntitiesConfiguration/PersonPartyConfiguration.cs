using MarcouEvento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcouEvento.Infra.Data.EntitiesConfiguration
{
    public class PersonPartyConfiguration : IEntityTypeConfiguration<PersonParty>
    {
        public void Configure(EntityTypeBuilder<PersonParty> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).HasConversion<int>().HasMaxLength(1).IsRequired();

            builder.HasOne(x => x.Administrator)
                .WithMany()
                .HasForeignKey(y => y.AdministratorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Guest)
                .WithMany()
                .HasForeignKey(y => y.GuestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Party)
                .WithMany()
                .HasForeignKey(y => y.PartyId)
                .OnDelete(DeleteBehavior.Restrict);                
        }
    }
}
