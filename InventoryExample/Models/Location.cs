using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryExample.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }
    }
}
