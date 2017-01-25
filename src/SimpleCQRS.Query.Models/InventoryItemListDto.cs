using System;

namespace SimpleCQRS.Query.Models
{
  
  public class InventoryItemListDto
  {
        public Guid Id {get;set;}
        public string Name {get;set;}

        public InventoryItemListDto()
        {
        }

        public InventoryItemListDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
  }
}