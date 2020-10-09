
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace FridA.Models
{
    public class Schedule
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //[BsonElement("Topic")]
        public string Topic { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Start { get; set; }
        
        
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime End { get; set; }

        public string Link { get; set; }

    }
}
