using System;

namespace HarryBotter.DataService
{
    public class Auction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}