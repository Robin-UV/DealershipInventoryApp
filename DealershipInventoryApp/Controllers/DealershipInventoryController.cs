using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DealershipInventoryApp.DataAccess.EF.Context;
using DealershipInventoryApp.DataAccess.EF.Models;
using DealershipInventoryApp.Models; 

namespace DealershipInventoryApp.Controllers
{
    public class DealershipInventoryController : Controller
    {
        private readonly DealershipInventoryContext _context;

        public DealershipInventoryController(DealershipInventoryContext context)
        {
            _context = context; 
        }

        public IActionResult Index()
        {
            DealershipInventoryViewModel model = new DealershipInventoryViewModel(_context); 
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int vehicleId, string make, string carModel, string bodyType, string trimLevel, short year, int miles, double price)
        {
            DealershipInventoryViewModel model = new DealershipInventoryViewModel(_context);

            DealershipInventory vehicle = new(vehicleId, make, carModel, bodyType, trimLevel, year, miles, price);

            model.SaveVehicle(vehicle);
            model.IsActionSuccess = true;
            model.ActionMessage = "Vehicle has been saved successfully.";

            return View(model); 
        }

        public IActionResult Update(int id)
        {
            DealershipInventoryViewModel model = new DealershipInventoryViewModel(_context, id);
            return View(model); 
        }

        public IActionResult Delete(int id)
        {
            DealershipInventoryViewModel model = new DealershipInventoryViewModel(_context);

            if (id > 0)
            {
                model.RemoveVehicle(id);
            }

            model.IsActionSuccess = true;
            model.ActionMessage = "Vehicle has been deleted successfully";
            return View("Index", model);
        }
    }
}

