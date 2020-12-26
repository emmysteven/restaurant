using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Configurations
{ 
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name).HasMaxLength(50).IsRequired();
            builder.Property(s => s.Website).HasMaxLength(50);
            builder.Property(s => s.Email).HasMaxLength(50).IsRequired();

            builder.Property(s => s.PhoneNumber).HasMaxLength(11).IsRequired();
            builder.Property(s => s.State).HasMaxLength(10).IsRequired();
            builder.Property(s => s.LocalGovernmentArea).HasMaxLength(20).IsRequired();

            builder.Property(s => s.Address).HasMaxLength(50).IsRequired();
            builder.Property(s => s.Created).ValueGeneratedOnAdd();
            // builder.Property(s => s.Updated).ValueGeneratedOnAddOrUpdate();

            builder.HasIndex(s => new
            {
                s.Name,
                s.Email,
                s.Website,
                s.PhoneNumber
            }).IsUnique();
        }
    }
}