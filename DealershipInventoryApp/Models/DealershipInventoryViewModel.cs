using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealershipInventoryApp.DataAccess.EF.Context;
using DealershipInventoryApp.DataAccess.EF.Models;
using DealershipInventoryApp.DataAccess.EF.Repositories; 

namespace DealershipInventoryApp.Models
{
	public class DealershipInventoryViewModel
	{
		private DealershipInventoryRepository _repo;

		public List<DealershipInventory> DealershipInventoryList { get; set; }

		public DealershipInventory CurrentVehicle { get; set; } 

		public bool IsActionSuccess { get; set; }

		public string ActionMessage { get; set; } 

		public DealershipInventoryViewModel(DealershipInventoryContext context)
		{
			_repo = new DealershipInventoryRepository(context);
			DealershipInventoryList = GetAllVehiclesInInventory();
			CurrentVehicle = DealershipInventoryList.FirstOrDefault(); 
        }

		public DealershipInventoryViewModel(DealershipInventoryContext context, int vehicleId)
		{
			_repo = new DealershipInventoryRepository(context);
			DealershipInventoryList = GetAllVehiclesInInventory();

			if (vehicleId < 0)
			{
				CurrentVehicle = GetVehicle(vehicleId); 
			}
			else
			{
				CurrentVehicle = new DealershipInventory(); 
			}
		}

		public void SaveVehicle(DealershipInventory vehicle)
		{
			if (vehicle.VehicleId > 0)
			{
				_repo.Update(vehicle); 
			}
			else
			{
				vehicle.VehicleId = _repo.Create(vehicle); 
			}

			DealershipInventoryList = GetAllVehiclesInInventory();
			CurrentVehicle = GetVehicle(vehicle.VehicleId); 
		}

		public void RemoveVehicle(int vehicleID)
		{
			_repo.Delete(vehicleID);
			DealershipInventoryList = GetAllVehiclesInInventory();
			CurrentVehicle = DealershipInventoryList.FirstOrDefault()!; 
		}

		public List<DealershipInventory> GetAllVehiclesInInventory()
		{
			return _repo.GetAllVehiclesInInventory(); 
		}

		public DealershipInventory GetVehicle(int vehicleId)
		{
			return _repo.GetVehicleByID(vehicleId); 
		}
	}
}

