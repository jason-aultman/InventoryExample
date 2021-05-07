using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryExample.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Location Location { get; set; }
        public string Lot { get; set; }
        public double Quantity { get; set; }
        public string Units { get; set; }
        public int LocationId { get; set; }
    }
}
