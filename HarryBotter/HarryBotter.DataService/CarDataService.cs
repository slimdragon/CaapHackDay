﻿using System.Collections.Generic;

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
                "Fiat",
                "Honda",
                "Nissan",
                "More!..."
            };
        }

        public IEnumerable<string> ListMakesPage2()
        {
            return new List<string>
            {
                "Hyundai",
                "VW",
                "Renault",
                "Isuzu",
                "Chevy",
                "Holden",
                "More!..."
            };
        }
    }
}
