using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.UserId).IsRequired();
            builder.Property(b => b.ShopId).IsRequired();

            builder.Property(b => b.Created).ValueGeneratedOnAdd();
            // builder.Property(b => b.Updated).ValueGeneratedOnAddOrUpdate();
        }
    }
}