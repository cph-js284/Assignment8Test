using System.Collections.Generic;

namespace mariospizzamongo
{
    public interface IDocumentContext
    {
        void AddOrder(Order order);
        Order GetOrder(int id);
        IEnumerable<Order> GetAllOrders();
        void DeleteOrder(string id);
    }
}