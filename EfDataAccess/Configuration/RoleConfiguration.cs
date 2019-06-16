using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domen;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfDataAccess.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(45);

            builder.HasMany(p => p.Auctioners)
                .WithOne(a => a.Role)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(a => a.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
