using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryExample.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public List<InventoryItem> InventoryItems { get; set; } 
    }
}