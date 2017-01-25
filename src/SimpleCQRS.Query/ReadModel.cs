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
        private InventoryQueryContext _context;

        public ReadModel(InventoryQueryContext context)
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
}