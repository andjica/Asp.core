using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domen;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfDataAccess.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(i => i.Url)
                .HasMaxLength(300);

            builder.Property(a => a.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
