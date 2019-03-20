using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mariospizzamongo
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int _Hid { get; set; }
        public string CustomerName { get; set; }
        public DateTime TimeStamp { get; set; }
        public List<Item> oItems { get; set; } 

    }
}