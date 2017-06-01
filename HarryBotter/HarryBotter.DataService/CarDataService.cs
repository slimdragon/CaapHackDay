using System.Collections.Generic;

namespace HarryBotter.DataService
{
    public class CarDataService
    {
        public IEnumerable<string> ListMakes()
        {
            return new List<string>
            {
                "Mercedes",
                "BMW",
                "Ford",
                "Fiat"
            };
        }
    }
}
