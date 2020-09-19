using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TradeBooks.Models;

namespace TradeBooks.Services
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {
            //
        }

        public DbSet<UnitHolder> UnitHolders { get; set; }
        public DbSet<Fund> Funds { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UnitHolder>()
                .Property(x => x.UnitHolderId)
                .IsFixedLength(true);

            modelBuilder.Entity<Subscription>()
                .Property(x => x.OwnerId)
                .IsFixedLength(true);

            // handle enum convert int when save to database
            modelBuilder.Entity<UnitHolder>()
                .Property(x => x.Gender)
                .HasConversion<string>();

        }
    }
}