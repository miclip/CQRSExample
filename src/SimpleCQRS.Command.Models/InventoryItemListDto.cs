using System;

namespace SimpleCQRS.Command.Models
{
  
  public class InventoryItemListDto
  {
        public string Id {get;set;}
        public string Name {get;set;}

        public InventoryItemListDto()
        {
        }

        public InventoryItemListDto(Guid id, string name)
        {
            Id = id.ToString();
            Name = name;
        }
  }
}