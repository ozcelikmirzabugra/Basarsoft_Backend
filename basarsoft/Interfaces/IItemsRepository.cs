using System.Collections.Generic;
using basarsoft.Models;

namespace basarsoft.Interfaces
{
    public interface IItemsRepository<T> where T : class
    {
        IEnumerable<Items> GetAllItems();
        Items GetItemById(int id);
        void CreateItem(T item);
        void UpdateItem(int id, T item);
        void DeleteItem(int id);
    }
}
