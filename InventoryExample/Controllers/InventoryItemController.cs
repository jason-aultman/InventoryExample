using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryExample.Data;
using InventoryExample.Models;
using InventoryExample.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryExample.Controllers
{
    public class InventoryItemController : Controller
    {
        private readonly InventoryDbContext _context;
        public InventoryItemController(InventoryDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var inventoryItems = _context.InventoryItems.Include(i => i.Manufacturer).Include(i => i.Location).ToList();
            var sortedInventory = inventoryItems.OrderBy(i => i.Name).ToList();
            return View(sortedInventory);
        }
        public IActionResult Edit(int Id)
        {
            InventoryEditViewModel inventoryEditViewModel = new InventoryEditViewModel();
            if (Id == 0)
            {
                inventoryEditViewModel.InventoryItem = new Models.InventoryItem();
                inventoryEditViewModel.LocationSelectedId = 0;
                inventoryEditViewModel.ManufacturerSelectedId = 0;
                inventoryEditViewModel.Locations = _context.Locations.ToList();
                inventoryEditViewModel.Manufacturers = _context.Manufacturers.ToList();

            }
            else
            {
                inventoryEditViewModel.InventoryItem = _context.InventoryItems.Where(c => c.Id == Id).Single();
                inventoryEditViewModel.Locations = _context.Locations.ToList();
                inventoryEditViewModel.Manufacturers = _context.Manufacturers.ToList();
                inventoryEditViewModel.LocationSelectedId = inventoryEditViewModel.InventoryItem.LocationId;
                inventoryEditViewModel.ManufacturerSelectedId = inventoryEditViewModel.InventoryItem.Manufacturer.Id;
            }
            return View(inventoryEditViewModel);
        }
        public IActionResult Edited(int Id, string Name, string Lot, int LocationSelectedId, int ManufacturerSelectedId, double Quantity, string Units )
        {
            InventoryItem inventoryItem = new InventoryItem();
            if (Id != 0)
            {
                inventoryItem = _context.InventoryItems.Where(i => i.Id == Id).SingleOrDefault();
                
            }
                inventoryItem.Name = Name;
                inventoryItem.Lot = Lot;
                inventoryItem.Quantity = Quantity;
                inventoryItem.Units = Units;
                inventoryItem.Location = _context.Locations.Where(c => c.Id == LocationSelectedId).SingleOrDefault();
                inventoryItem.Manufacturer = _context.Manufacturers.Where(c => c.Id == ManufacturerSelectedId).SingleOrDefault();

            if (ModelState.IsValid && Id == 0)
            {
                _context.Add(inventoryItem);
                _context.SaveChanges();
            }
            else if (ModelState.IsValid && Id != 0)
            {
                _context.Update(inventoryItem);
                _context.SaveChanges();
            }
            else return View(new NotFoundResult());
                
                
               
            
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var ItemToDelete = _context.InventoryItems.Where(i => i.Id == Id).SingleOrDefault();
            if (ItemToDelete!=null)
            {
                _context.Remove(ItemToDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
