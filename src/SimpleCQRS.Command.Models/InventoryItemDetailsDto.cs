using System;

namespace SimpleCQRS.Command.Models
{
    public class InventoryItemDetailsDto
    {
        public string Id {get;set;}
        public string Name {get;set;}
        public int CurrentCount {get;set;}
        public int Version {get;set;}

        public InventoryItemDetailsDto()
        {}

        public InventoryItemDetailsDto(Guid id, string name, int currentCount, int version)
        {
            Id = id.ToString();
            Name = name;
            CurrentCount = currentCount;
            Version = version;
        }
    }    
}
