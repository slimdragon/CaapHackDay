using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Flurl.Http;

namespace HarryBotter.DataService
{
    public class AuctionsDataService
    {
        private static List<Auction> _auctions;

        public AuctionsDataService()
        {
            _auctions = new List<Auction>
            {
                new Auction
                {
                    Name = "Electric Vehicles",
                    State = "QLD",
                    Status = "In Progress"
                },
                new Auction
                {
                    Name = "Luxury Cars",
                    State = "ACT",
                    Status = "In Progress"
                },
                new Auction
                {
                    Name = "General Vehicles",
                    State = "VIC",
                    Status = "Future",
                    Date = DateTime.Now.AddDays(10)
                },
                new Auction
                {
                    Name = "Motor Vehicles",
                    State = "NSW",
                    Status = "In Progress"
                },
                new Auction
                {
                    Name = "E-Salvage",
                    State = "NSW",
                    Status = "In Progress"
                },
            };
            _auctions.ForEach(a => a.Id = Guid.NewGuid());
        }

        public IEnumerable<Auction> ListActions()
        {
            return _auctions;
        }

        public IEnumerable<Auction> ListActions(string state)
        {
            return _auctions.Where(a => a.State.Equals(state, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<Vehicle> ListVehicles(Guid auctionId)
        {
            var url = "https://picklesdev.azure-api.net/api/v1.0/vehicles/sold?make=Ford&model=Territory&limit=25";
            return url.WithHeader("Ocp-Apim-Subscription-Key", ConfigurationManager.AppSettings["SubscriptionKey"]).GetJsonAsync<Vehicle[]>().Result;
        }
    }
}