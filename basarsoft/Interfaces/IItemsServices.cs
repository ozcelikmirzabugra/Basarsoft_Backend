using System.Collections.Generic;
using basarsoft.Models;

namespace basarsoft.Interfaces
{
    public interface IItemsService<Items> where Items : class
    {
        IEnumerable<Items> GetAllItems();
        Items GetItemById(int id);
        void CreateItem(Items item);
        void UpdateItem(int id, Items item);
        void DeleteItem(int id);
    }
}