using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Configurations;

public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Amount)
            .HasColumnType("decimal(18,2)").HasDefaultValue(0);

        builder.Property(t => t.Date);

        builder.Property(t => t.WalletId);

        builder.Property(t => t.GameId);

        builder.HasOne(t => t.Wallet)
            .WithMany(w => w.Purchases)
            .HasForeignKey(t => t.WalletId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}