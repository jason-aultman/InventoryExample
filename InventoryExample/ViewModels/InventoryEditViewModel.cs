using InventoryExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryExample.ViewModels
{
    public class InventoryEditViewModel
    {
        public InventoryItem InventoryItem { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
        public List<Location> Locations { get; set; }
        public int ManufacturerSelectedId { get; set; }
        public int LocationSelectedId { get; set; }
    }
}
