using System;
using Microsoft.EntityFrameworkCore;
using SimpleCQRS.Query.Models;



namespace SimpleCQRS.Query.DataAccess
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryItemDetailsDto>().ToTable("InventoryItemDetails")
                  .HasKey(c => c.Id);
            modelBuilder.Entity<InventoryItemListDto>().ToTable("InventoryItemList")
                  .HasKey(c => c.Id);
        }


        public override int SaveChanges()
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        public DbSet<InventoryItemDetailsDto> InventoryItemDetails { get; set; }
        public DbSet<InventoryItemListDto> InventoryItems { get; set; }

    }
}