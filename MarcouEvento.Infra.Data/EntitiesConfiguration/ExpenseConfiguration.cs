using MarcouEvento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcouEvento.Infra.Data.EntitiesConfiguration
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Value).HasPrecision(18, 2).IsRequired();

            builder.HasOne(x => x.Party)
                            .WithMany(y => y.Expenses)
                            .HasForeignKey(e => e.PartyId)
                            .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
