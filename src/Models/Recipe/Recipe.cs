using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;


namespace FridA.Models
{
    public class Recipe
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //[BsonElement("Topic")]
        public string name { get; set; }

        public List<Ingredient> ingredients { get; set; }

        public List<String> steps { get; set; }

    }

    public class Ingredient : WarehouseFood
    {
         public double quantity { get; set; }

    }
}
