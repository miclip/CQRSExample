using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SimpleCQRS.Query.Models;
using SimpleCQRS.Query.DataAccess;

namespace SimpleCQRS.Query
{
    public class ReadModel: IReadModel
    {
        private InventoryContext _context;

        public ReadModel(InventoryContext context)
        {
            _context = context;
        }

        public IEnumerable<InventoryItemListDto> GetInventoryItems()
        {
            return _context.InventoryItems;
        }

        public InventoryItemDetailsDto GetInventoryItemDetails(Guid id)
        {
            return _context.InventoryItemDetails.Single(i=>i.Id == id);
        }
    }

    public static class BullShitDatabase
    {
        public static Dictionary<Guid, InventoryItemDetailsDto> details = new Dictionary<Guid,InventoryItemDetailsDto>();
        public static List<InventoryItemListDto> list = new List<InventoryItemListDto>();
    }
}