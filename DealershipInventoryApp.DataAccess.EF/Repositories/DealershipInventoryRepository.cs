using DealershipInventoryApp.DataAccess.EF.Models;
using DealershipInventoryApp.DataAccess.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealershipInventoryApp.DataAccess.EF.Repositories
{
	public partial class DealershipInventoryRepository
	{
		DealershipInventoryContext _dbContext;

		public DealershipInventoryRepository(DealershipInventoryContext dbContext)
		{
			_dbContext = dbContext; 
		}

		public int Create(DealershipInventory vehicle)
		{
			_dbContext.Add(vehicle);
			_dbContext.SaveChanges();

			return vehicle.VehicleId; 
		}

		public int Update(DealershipInventory vehicle)
		{
			DealershipInventory existingVehicle = _dbContext.DealershipInventory.Find(vehicle.VehicleId)!;

			existingVehicle.Make = vehicle.Make;
			existingVehicle.Model = vehicle.Model;
			existingVehicle.BodyType = vehicle.BodyType;
			existingVehicle.TrimLevel = vehicle.TrimLevel;
			existingVehicle.Year = vehicle.Year;
			existingVehicle.Miles = vehicle.Miles;
			existingVehicle.Price = vehicle.Price;

			_dbContext.SaveChanges();

			return existingVehicle.VehicleId; 
		}

		public bool Delete(int vehicleID)
		{
			DealershipInventory vehicle = _dbContext.DealershipInventory.Find(vehicleID)!;
			_dbContext.Remove(vehicle);
			_dbContext.SaveChanges();

			return true; 
		}

		public List<DealershipInventory> GetAllVehiclesInInventory()
		{
			List<DealershipInventory> dealershipInventoryList = _dbContext.DealershipInventory.ToList();

			return dealershipInventoryList; 
		}

		public DealershipInventory GetVehicleByID(int vehicleID)
		{
			DealershipInventory vehicle = _dbContext.DealershipInventory.Find(vehicleID)!;

			return vehicle; 
		}
	}
}

