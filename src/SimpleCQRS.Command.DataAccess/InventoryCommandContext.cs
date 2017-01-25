using System;
using Microsoft.EntityFrameworkCore;
using SimpleCQRS.Command.Models;

namespace SimpleCQRS.Command.DataAccess
{
    public class InventoryCommandContext : DbContext
    {
        public InventoryCommandContext(DbContextOptions<InventoryCommandContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryItemDetailsDto>().ToTable("InventoryItemDetails")
                  .HasKey(c => c.Id);
            modelBuilder.Entity<InventoryItemListDto>().ToTable("InventoryItemList")
                  .HasKey(c => c.Id);
        }

        public DbSet<InventoryItemDetailsDto> InventoryItemDetails { get; set; }
        public DbSet<InventoryItemListDto> InventoryItems { get; set; }

    }
}