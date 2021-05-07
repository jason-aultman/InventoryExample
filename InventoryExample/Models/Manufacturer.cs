using System.Collections.Generic;

namespace InventoryExample.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<InventoryItem> InventoryItems { get; set; } 
    }
}