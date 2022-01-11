using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName).HasMaxLength(30).IsRequired();
        builder.Property(u => u.LastName).HasMaxLength(30).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(50).IsRequired();

        builder.Property(u => u.Password).HasMaxLength(100).IsRequired();
        builder.Property(u => u.PhoneNumber).HasMaxLength(11).IsRequired();
        builder.Property(p => p.Role).HasMaxLength(6).IsRequired();

        // builder.Property(u => u.Created).ValueGeneratedOnAdd();
        // builder.Property(u => u.Updated).ValueGeneratedOnAddOrUpdate();
        builder.HasIndex(u => new {u.PhoneNumber, u.Email}).IsUnique();
    }
}