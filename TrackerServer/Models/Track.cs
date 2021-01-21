using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrackerServer.Models
{
    [BsonIgnoreExtraElements]
    public class Track
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public int Duration { get; set; }

        public decimal Distance { get; set; }

        public string Description { get; set; }

        public string Sport { get; set; }

        //public Coordinate[] Coordinates { get; set; }
    }
}
