using System;
using System.Collections.Generic;

namespace DealershipInventoryApp.DataAccess.EF.Models
{
	public class DealershipInventory
	{
        public int VehicleId { get; set; } 
        public string Make { get; set; }
        public string Model { get; set; }
        public string BodyType { get; set; }
        public string TrimLevel { get; set; }
        public short Year { get; set; }
        public int Miles { get; set; }
        public double Price { get; set; }

        public DealershipInventory(int vehicleId, string make, string model, string bodyType, string trimLevel, short year, int miles, double price)
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

