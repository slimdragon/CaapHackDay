using System;
using System.Configuration;
using Flurl.Http;

namespace HarryBotter.DataService
{
    public class LuisService
    {
        private readonly string _endpoint;

        public LuisService()
        {
            _endpoint = ConfigurationManager.AppSettings["LUIS.Endpoint"];
        }

        public LuisResponse Score(string query)
        {
            try
            {
                return new LuisResponse
                {
                    LuisResult = (_endpoint + query).GetJsonAsync<PicklesLuisResult>().Result,
                    Succeeded = true,
                };
            }
            catch(AggregateException ex)
            {
             return new LuisResponse(); 
            }
        }
    }

    public class LuisResponse
    {
        public PicklesLuisResult LuisResult { get; set; }
        public bool Succeeded { get; set; }
    }

    public class CustomerIntent
    {
        public string Intent { get; set; }
        public decimal Score { get; set; }
    }

    public class PicklesLuisResult
    {
        public CustomerIntent TopScoringIntent { get; set; }
        /*{
  "query": "I would like to buy a car",
  "topScoringIntent": {
    "intent": "Buy a Car",
    "score": 0.95874
  },
  "entities": [
    {
      "entity": "car",
      "type": "Car",
      "startIndex": 22,
      "endIndex": 24,
      "score": 0.9778882
    }
  ]
}*/
    }
}
