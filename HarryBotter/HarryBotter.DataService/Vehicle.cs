using System.Collections.Generic;

namespace HarryBotter.DataService
{
    public class Response
    {
        public Vehicle[] Documents { get; set; }
    }
    public class Vehicle
    {
        public string Sale_Type_name { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Body_Tyep { get; set; }
        public string Fuel_Type { get; set; }
        public string Transmission_Type { get; set; }
        public string Variant { get; set; }
        public string Series { get; set; }
        public string Model_Year { get; set; }
        public string Region { get; set; }
        public string Colour { get; set; }
        public string Auction_Sale_Type { get; set; }
        public string Sold_Date { get; set; }
        public string ImageUrls { get; set; }
        public string Description { get; set; }
    }
}