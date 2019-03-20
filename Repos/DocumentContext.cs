using System.Collections.Generic;
using MongoDB.Driver;

namespace mariospizzamongo
{
    public class DocumentContext : IDocumentContext
    {
        MongoClient client;
        IMongoDatabase database;

        public DocumentContext()
        {
            client = new MongoClient("mongodb://172.17.0.2:27017");
            database = client.GetDatabase("MarioDb");
        }
        public async void AddOrder(Order order)
        {
            var collection = database.GetCollection<Order>("OrderCollection");
            await collection.InsertOneAsync(order);        
        }

        public void DeleteOrder(string strid)
        {
            var collection = database.GetCollection<Order>("OrderCollection");
            collection.DeleteOne(x=>x.Id == strid);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var collection = database.GetCollection<Order>("OrderCollection");
            var models = collection.Find(x=>true).ToEnumerable();
            return models;

        }

        public Order GetOrder(int id)
        {
            var collection = database.GetCollection<Order>("OrderCollection");
            var model = collection.Find(x=>x._Hid == id).FirstOrDefault();
            return model;
        }
    }
}