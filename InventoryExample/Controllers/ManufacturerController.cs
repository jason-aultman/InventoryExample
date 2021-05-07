using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryExample.Data;
using InventoryExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryExample.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly InventoryDbContext _context;
        public ManufacturerController(InventoryDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var manufacturers = _context.Manufacturers.ToList();
            
            return View(manufacturers);
        }
        public IActionResult Edit(int Id)
        {
            Manufacturer manufacturer;
            if(Id==0)
            {
                manufacturer = new Manufacturer();
            }
            else
            {
                manufacturer = _context.Manufacturers.Single(m => m.Id == Id);
            }
            return View(manufacturer);
        }
        public async Task<IActionResult> Edited(Manufacturer manufacturer)
        {
            _context.Add(manufacturer);
             await _context.SaveChangesAsync();
             return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var removeManufacturer = _context.Manufacturers.SingleOrDefault(m => m.Id == Id);
            if(removeManufacturer!=null)
            {
                _context.Manufacturers.Remove(removeManufacturer);
                _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
