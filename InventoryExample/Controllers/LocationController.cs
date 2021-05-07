using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryExample.Data;
using InventoryExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryExample.Controllers
{
    public class LocationController : Controller
    {
        private readonly InventoryDbContext _context;
        public LocationController(InventoryDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var locations = _context.Locations.ToList();
            return View(locations);
        }
        public IActionResult Edit(int Id)
        {
            Location location;
            if (Id == 0)
            {
                location = new Location();
            }
            else
            {
                location = _context.Locations.Single(m => m.Id == Id);
            }
            return View(location);
        }
        public async Task<IActionResult> Edited(Location location)
        {
            _context.Add(location);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            _context.Remove(_context.Locations.Where(c => c.Id == Id).Single());
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
