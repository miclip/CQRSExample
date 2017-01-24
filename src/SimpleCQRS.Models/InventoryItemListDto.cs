using System;

namespace SimpleCQRS.Models
{
  public class InventoryItemListDto
  {
        public Guid Id;
        public string Name;

        public InventoryItemListDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
  }
}