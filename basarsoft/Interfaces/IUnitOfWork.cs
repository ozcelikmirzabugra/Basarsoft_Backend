using System.Collections.Generic;
using basarsoft.Models;

namespace basarsoft.Interfaces
{
    public interface IUniteOfWork<Items> where T : class
    {
        IEnumerable<T> GetAllItems();
        T GetItemById(int id);
        void CreateItem(T item);
        void UpdateItem(int id, T item);
        void DeleteItem(int id);
    }
}