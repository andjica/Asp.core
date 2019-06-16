using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domen;
using EfDataAccess.Configuration;
namespace EfDataAccess
{
    public class AuctionContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }

        public DbSet<Auctioner> Auctioners { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Good> Goods { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Auction> Auctions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=AuctionSql;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new AuctionerConfiguration());
            modelBuilder.ApplyConfiguration(new GoodConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AuctionConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());

        }
    }
}
