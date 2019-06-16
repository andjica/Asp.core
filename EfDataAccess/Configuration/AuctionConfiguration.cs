using System;
using System.Collections.Generic;
using System.Text;
using Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfDataAccess.Configuration
{
    public class AuctionConfiguration : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {

            //builder.HasKey(a => new { a.GoodId, a.AuctionerId });

            builder.Property(a => a.MaxPrice)
                .IsRequired();

            builder.Property(a => a.ValidUntil)
                .IsRequired();

            builder.Property(a => a.CreatedAt).HasDefaultValueSql("GETDATE()");

        }
    }
}
