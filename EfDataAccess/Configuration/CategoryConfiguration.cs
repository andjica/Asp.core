using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domen;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfDataAccess.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Title)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasMaxLength(150);

            builder.HasMany(c => c.Goods)
                .WithOne(g => g.Category)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(a => a.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
