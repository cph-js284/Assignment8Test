using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mariospizzamongo
{
    public class Item
    {
        public int _HId { get; set; }
        public string Text { get; set; }
        public double Price { get; set; }
    }
}