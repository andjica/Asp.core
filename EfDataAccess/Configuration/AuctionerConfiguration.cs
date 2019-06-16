using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domen;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfDataAccess.Configuration
{
    public class AuctionerConfiguration : IEntityTypeConfiguration<Auctioner>
    {
        public void Configure(EntityTypeBuilder<Auctioner> builder)
        {
            builder.Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(a => a.Password)
                .IsRequired()
                .HasMaxLength(30);
               

            builder.HasIndex(a => a.Email).IsUnique();

            builder.Property(a => a.CreatedAt).HasDefaultValueSql("GETDATE()");
                
           
        }
    }
}
