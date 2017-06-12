using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Flurl.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public async Task<IEnumerable<Vehicle>> ListVehiclesAsync(string auctionName, string make, string model)
        {
            //call api and search vehicles
            var url = $"http://webapplication120170608053956.azurewebsites.net/api/cars?make={make}&model={model}";
            IFlurlClient client = url.WithHeader("Accept", "application/json");
            Task <string> strTask = client.GetStringAsync();

            //add a root emelemt to match the model and deserialize
            string str = "{\"Documents\":" + strTask.Result + "}";
            var jsonObject = JsonConvert.DeserializeObject<Response>(str);
            List<Vehicle> vehicles = jsonObject.Documents;

            //Add image url to vehicles
            ImagesResponse carImages = null;
            foreach (var veh in vehicles)
            {
                //get images from image management API
                carImages = GetImages(vehicles, veh.ItemId);

                //just get any relevant image
                foreach (var image in carImages.images)
                {
                    if (image.Value.item_id == veh.ItemId)
                    {
                        veh.ImageUrl = image.Value.cdn_url;
                        //stop at first match
                        break;
                    }
                }
            }

            return jsonObject.Documents;
        }

        public static ImagesResponse GetImages(List<Vehicle> cars, string itemId)
        {
            var imageUrl = $"https://picklesprd.azure-api.net/api/v1.0/imageretrieval/getImages?item_id={itemId}";
            IFlurlClient client = imageUrl.WithHeader("Ocp-Apim-Subscription-Key", ConfigurationManager.AppSettings["GetImagesSubscriptionKey"]);

            Task<string> strTask = client.GetStringAsync();

            string str2 = "{\"images\":" + strTask.Result + "}";

            ImagesResponse jsonObject = new ImagesResponse();
            jsonObject = JsonConvert.DeserializeObject<ImagesResponse>(str2);
            return jsonObject;
        }
    }
}