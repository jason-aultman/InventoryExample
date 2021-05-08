using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryExample.Data;
using InventoryExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (manufacturer.Id == 0)
            {
                _context.Add(manufacturer);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Update(manufacturer);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var removeManufacturer = _context.Manufacturers.SingleOrDefault(m => m.Id == Id);
            if(removeManufacturer!=null)
            {
                _context.Manufacturers.Remove(removeManufacturer);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int Id)
        {
            var manufacturer = _context.Manufacturers.Where(m => m.Id == Id).Include(m => m.InventoryItems).SingleOrDefault();
            var items = _context.InventoryItems.Where(i => i.Manufacturer.Id == manufacturer.Id).Include(l=>l.Location).ToList();
            manufacturer.InventoryItems = items;
            return View(manufacturer);
        }
    }
}
