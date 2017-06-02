using System.Collections.Generic;
using System.Linq;

namespace HarryBotter.DataService
{
    public class VehicleMake
    {
        public string Make { get; set; }
        public string Model { get; set; }
    }
    public class CarDataService
    {
        private readonly List<VehicleMake> _vehicleMakes;
            private readonly List<string> _makes;

        public CarDataService()
        {
            _vehicleMakes = new List<VehicleMake>();
            _vehicleMakes.AddRange(new List<VehicleMake>
            {
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Territory"
                },
                new VehicleMake()
                {
                    Make = "Mazda",
                    Model = "Bt-50"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Camry"
                },
                new VehicleMake()
                {
                    Make = "Volkswagen",
                    Model = "Amarok"
                },
                new VehicleMake()
                {
                    Make = "Jeep",
                    Model = "Wrangler"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Kluger"
                },
                new VehicleMake()
                {
                    Make = "Nissan",
                    Model = "Navara"
                },
                new VehicleMake()
                {
                    Make = "Holden",
                    Model = "Commodore"
                },
                new VehicleMake()
                {
                    Make = "Holden",
                    Model = "Berlina"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Falcon"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Falcon"
                },
                new VehicleMake()
                {
                    Make = "Peugeot",
                    Model = "308"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "EcoSport"
                },
                new VehicleMake()
                {
                    Make = "Volkswagen",
                    Model = "Golf"
                },
                new VehicleMake()
                {
                    Make = "Volkswagen",
                    Model = "Golf"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Avensis Verso"
                },
                new VehicleMake()
                {
                    Make = "Hyundai",
                    Model = "Santa Fe"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "RAV4"
                },
                new VehicleMake()
                {
                    Make = "Hyundai",
                    Model = "ix35"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Hiace"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Corolla"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Landcruiser"
                },
                new VehicleMake()
                {
                    Make = "Holden",
                    Model = "Ute"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Falcon"
                },
                new VehicleMake()
                {
                    Make = "Lexus",
                    Model = "IS250"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Hilux"
                },
                new VehicleMake()
                {
                    Make = "BMW",
                    Model = "X3"
                },
                new VehicleMake()
                {
                    Make = "Holden",
                    Model = "Ute"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Falcon"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Territory"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Territory"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Falcon"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Aurion"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Hilux"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Kluger"
                },
                new VehicleMake()
                {
                    Make = "Mitsubishi",
                    Model = "Pajero"
                },
                new VehicleMake()
                {
                    Make = "Mitsubishi",
                    Model = "Pajero"
                },
                new VehicleMake()
                {
                    Make = "Mitsubishi",
                    Model = "Pajero"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Kluger"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Kluger"
                },
                new VehicleMake()
                {
                    Make = "Mitsubishi",
                    Model = "Pajero"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Kluger"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Kluger"
                },
                new VehicleMake()
                {
                    Make = "Holden",
                    Model = "Commodore"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "RAV4"
                },
                new VehicleMake()
                {
                    Make = "Holden",
                    Model = "Captiva"
                },
                new VehicleMake()
                {
                    Make = "Holden",
                    Model = "Captiva"
                },
                new VehicleMake()
                {
                    Make = "Nissan",
                    Model = "X-Trail"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Focus"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Ranger"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Ranger"
                },
                new VehicleMake()
                {
                    Make = "Jeep",
                    Model = "Wrangler"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Falcon"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Falcon"
                },
                new VehicleMake()
                {
                    Make = "Holden",
                    Model = "Commodore"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Corolla"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Territory"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Hilux"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Corolla"
                },
                new VehicleMake()
                {
                    Make = "Holden",
                    Model = "Cruze"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Camry"
                },
                new VehicleMake()
                {
                    Make = "Nissan",
                    Model = "Dualis"
                },
                new VehicleMake()
                {
                    Make = "Hyundai",
                    Model = "ix35"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "RAV4"
                },
                new VehicleMake()
                {
                    Make = "Holden",
                    Model = "Commodore"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Hilux"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Aurion"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "86"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Ranger"
                },
                new VehicleMake()
                {
                    Make = "Volkswagen",
                    Model = "Golf"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Ranger"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Falcon"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Camry"
                },
                new VehicleMake()
                {
                    Make = "Holden",
                    Model = "Cruze"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Falcon"
                },
                new VehicleMake()
                {
                    Make = "Holden",
                    Model = "Commodore"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Falcon"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Hilux"
                },
                new VehicleMake()
                {
                    Make = "Nissan",
                    Model = "X-Trail"
                },
                new VehicleMake()
                {
                    Make = "Kia",
                    Model = "Sportage"
                },
                new VehicleMake()
                {
                    Make = "Kia",
                    Model = "Carnival"
                },
                new VehicleMake()
                {
                    Make = "Subaru",
                    Model = "Forester"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Territory"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Focus"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Tarago"
                },
                new VehicleMake()
                {
                    Make = "Holden",
                    Model = "Colorado"
                },
                new VehicleMake()
                {
                    Make = "Hyundai",
                    Model = "ix35"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Camry"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Camry"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Hilux"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Yaris"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Falcon"
                },
                new VehicleMake()
                {
                    Make = "Ford",
                    Model = "Falcon"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Camry"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Landcruiser Prado"
                },
                new VehicleMake()
                {
                    Make = "Holden",
                    Model = "Ute"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Hilux"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Landcruiser Prado"
                },
                new VehicleMake()
                {
                    Make = "Mitsubishi",
                    Model = "Triton"
                },
                new VehicleMake()
                {
                    Make = "Toyota",
                    Model = "Hilux"
                }
            });
            var allVehicleMakes = (from v in _vehicleMakes
                select v.Make).ToList();
            _makes = new List<string>();
            foreach (var vehicleMake in allVehicleMakes)
            {
                if(_makes.Contains(vehicleMake))
                    continue;
                _makes.Add(vehicleMake);
            }
        }

        public IEnumerable<string> ListMakes()
        {
            var list =  _makes.OrderBy(a => a).Take(10).ToList();
            list.Add("More!...");
            return list;
        }

        public IEnumerable<string> ListModels(string make)
        {
            return _vehicleMakes.Where(a => a.Make == make).OrderBy(a => a.Model).Select(a => a.Model).Distinct().ToList();
        }

        public IEnumerable<string> ListMakesPage2()
        {
            var list = _makes.OrderBy(a => a).Skip(10).ToList();
            return list;
        }
    }
}
