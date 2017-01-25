using System;
using System.Collections.Generic;
using SimpleCQRS.Query.Models;

namespace SimpleCQRS.Query
{
    public interface IReadModel
    {
        IEnumerable<InventoryItemListDto> GetInventoryItems();
        InventoryItemDetailsDto GetInventoryItemDetails(Guid id);
    }
}
