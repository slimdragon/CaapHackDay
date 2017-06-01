using System.Collections.Generic;

namespace HarryBotter.DataService
{
    public class VehicleTypesDataService
    {
        public IEnumerable<string> ListVehicleTypes()
        {
            return new List<string>()
            {
                "Truck",
                "Car",
                "Salvage"
            };
        }
    }
}
