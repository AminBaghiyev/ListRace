using ListRace.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListRace.DL.Configurations;

public class PlaceConfiguration : IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder
            .Property(e => e.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(e => e.Description)
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(e => e.MinPrice)
            .HasPrecision(10, 2)
            .IsRequired();

        builder
            .Property(e => e.MaxPrice)
            .HasPrecision(10, 2)
            .IsRequired();

        builder
            .Property(e => e.Rating)
            .HasPrecision(2, 1)
            .IsRequired();
    }
}
