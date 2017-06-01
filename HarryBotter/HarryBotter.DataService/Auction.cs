using System;
using System.Runtime.Serialization;

namespace HarryBotter.DataService
{
    [Serializable]
    public class Auction : ISerializable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Text", $"<div>{Name} - {Id}</div>");
        }
    }
}