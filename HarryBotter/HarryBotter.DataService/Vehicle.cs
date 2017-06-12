using Newtonsoft.Json;
using System.Collections.Generic;

namespace HarryBotter.DataService
{
    //[JsonArrayAttribute]
    public class Response
    {
        public List<Vehicle> Documents { get; set; }

    }

    //public class Vehicle
    //{
    //    public string Sale_Type_name { get; set; }
    //    public string Make { get; set; }
    //    public string Model { get; set; }
    //    public string Body_Tyep { get; set; }
    //    public string Fuel_Type { get; set; }
    //    public string Transmission_Type { get; set; }
    //    public string Variant { get; set; }
    //    public string Series { get; set; }
    //    public string Model_Year { get; set; }
    //    public string Region { get; set; }
    //    public string Colour { get; set; }
    //    public string Auction_Sale_Type { get; set; }
    //    public string Sold_Date { get; set; }
    //    public string Id { get; set; }
    //    public string Description { get; set; }
    //    public string ImageUrl { get; set; }
    //}


   // [JsonArrayAttribute]
    public class Vehicle
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Odometer { get; set; }
        public string Rego { get; set; }
        public string Year { get; set; }
        public string PriceGuide { get; set; }
        public string Description { get; set; }
        public string ItemId { get; set; }

        public string ImageUrl { get; set; }


    }
}