using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SimpleCQRS.Command.Models;
using SimpleCQRS.Command.DataAccess;

namespace SimpleCQRS.Command
{
    public class InventoryListView : Handles<InventoryItemCreated>, Handles<InventoryItemRenamed>, Handles<InventoryItemDeactivated>
    {
        private InventoryCommandContext _context;

        public InventoryListView(DbContextOptionsBuilder<InventoryCommandContext> optionsBuilder)
        {
            _context = new InventoryCommandContext(optionsBuilder.Options);
        }

        public void Handle(InventoryItemCreated message)
        {
            _context.InventoryItems.Add(new InventoryItemListDto(message.Id, message.Name));
            _context.SaveChanges();
        }

        public void Handle(InventoryItemRenamed message)
        {
            var item = _context.InventoryItems.FirstOrDefault(x => x.Id == message.Id.ToString());

            item.Name = message.NewName;
            _context.SaveChanges();
            
        }

        public void Handle(InventoryItemDeactivated message)
        {
            var item = _context.InventoryItems.FirstOrDefault(x => x.Id == message.Id.ToString());
            _context.InventoryItems.Remove(item);
            _context.SaveChanges();
        }
    }

    public class InventoryItemDetailView : Handles<InventoryItemCreated>, Handles<InventoryItemDeactivated>, Handles<InventoryItemRenamed>, Handles<ItemsRemovedFromInventory>, Handles<ItemsCheckedInToInventory>
    {
        private InventoryCommandContext _context;

        public InventoryItemDetailView(DbContextOptionsBuilder<InventoryCommandContext> optionsBuilder)
        {   
           
           _context = new InventoryCommandContext(optionsBuilder.Options);
        }

        public void Handle(InventoryItemCreated message)
        {
            _context.InventoryItemDetails.Add(new InventoryItemDetailsDto(message.Id, message.Name, 0,0));
            _context.SaveChanges();
        }

        public void Handle(InventoryItemRenamed message)
        {
            var item = _context.InventoryItemDetails.FirstOrDefault(i=>i.Id == message.Id.ToString());
            item.Name = message.NewName;
            item.Version = message.Version;
            _context.SaveChanges();
        }

        public void Handle(ItemsRemovedFromInventory message)
        {
            var item = _context.InventoryItemDetails.FirstOrDefault(i=>i.Id == message.Id.ToString());
            item.CurrentCount -= message.Count;
            item.Version = message.Version;
            _context.SaveChanges();
        }

        public void Handle(ItemsCheckedInToInventory message)
        {
            var item = _context.InventoryItemDetails.FirstOrDefault(i=>i.Id == message.Id.ToString());
            item.CurrentCount += message.Count;
            item.Version = message.Version;
            _context.SaveChanges();
        }

        public void Handle(InventoryItemDeactivated message)
        {
            var item = _context.InventoryItemDetails.FirstOrDefault(i=>i.Id == message.Id.ToString());
            _context.InventoryItemDetails.Remove(item);
            _context.SaveChanges();
        }
    }

    

    
}
