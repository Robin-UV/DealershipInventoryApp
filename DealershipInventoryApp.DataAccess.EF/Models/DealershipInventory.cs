using System;
using System.Collections.Generic;

namespace DealershipInventoryApp.DataAccess.EF.Models
{
	public class DealershipInventory
	{
        public int VehicleId { get; set; } 
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string BodyType { get; set; } = null!;
        public string TrimLevel { get; set; } = null!;
        public int Year { get; set; }
        public int Miles { get; set; }
        public double Price { get; set; }

        public DealershipInventory(int vehicleId, string make, string model, string bodyType, string trimLevel, int year, int miles, double price)
        {
            VehicleId = vehicleId;
            Make = make;
            Model = model;
            BodyType = bodyType;
            TrimLevel = trimLevel;
            Year = year;
            Miles = miles;
            Price = price;
        }

        public DealershipInventory()
        {

        }
    }
}

