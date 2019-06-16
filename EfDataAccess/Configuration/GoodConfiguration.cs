using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domen;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfDataAccess.Configuration
{
    public class GoodConfiguration : IEntityTypeConfiguration<Good>
    {
        public void Configure(EntityTypeBuilder<Good> builder)
        {
            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(g => g.Description)
               .IsRequired()
               .HasMaxLength(250);

            builder.HasIndex(g => g.Title).IsUnique();

            builder.HasMany(a => a.Auctions)
                .WithOne(g => g.Good)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(i => i.Images)
                .WithOne(g => g.Good)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(a => a.CreatedAt).HasDefaultValueSql("GETDATE()");


        }
    }
}
